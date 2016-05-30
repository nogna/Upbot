//************************************************************************************************
//
// © 2016       General Electric Company
//
// Description  See class summary below.
//
// History      See source code control system.
//
//************************************************************************************************
using System;
using GE.Healthcare.UNICORN.PluginAPI;
using GE.Healthcare.UNICORN.PluginAPI.AdvancedReportingAPI;
using GE.Healthcare.UNICORN.Plugins.SystemData;
using UNICORNsnelib;
using System.IO;
using System.Drawing.Imaging;

namespace GE.Healthcare.UNICORN.Plugin.UNICORNSocialNetworkExtension
{
    public class SystemMonitor
    {
        
        #region Global Variables
        /// <summary>
        /// Used to monitor, and errormessage
        /// </summary>
        private IAdvancedReportingAPI mReportingAPI;
        private IPDCSystemData mSystemDataAPI;
        private ILogTextMessageAPI mLogger;
          

        /// <summary>
        /// Logic for the swtich in WhenSystemDataAPIOnSystemState
        /// </summary>
        private SystemRunState mPreviousState;
        private bool mHasOneRun = false;
        private bool hasEnded = false;


        /// <summary>
        /// Variables for the message for twitter
        /// </summary>
        private String systemName, methodInfo, methodName, messageToTwitter;
        private IInstrumentStatus currentSystemStatus;
        private DateTime currentTime = DateTime.Now; 
        private DateTime startTime = DateTime.Now; //Starting time of the first run
        private int numberOfInterrupts;
        private Metafile metafile;

        #endregion

        #region Constructor and StartMonitoring()
        public SystemMonitor(ILogTextMessageAPI logger, IPDCSystemData systemDataAPI, IAdvancedReportingAPI reportingAPI)
        {       
            mLogger = logger;
            mSystemDataAPI = systemDataAPI;
            mReportingAPI = reportingAPI;

        }

        public void StartMonitoring()
        {
            // Subscribe to system state changed event
            mSystemDataAPI.SystemState += WhenSystemDataAPIOnSystemState;

        }

        #endregion

        /// <summary>
        /// Sends different message/image depending on what state the system currently has.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="systemRunStateEventArgs"></param>
        private void WhenSystemDataAPIOnSystemState(object sender, SystemRunStateEventArgs systemRunStateEventArgs)
        {
            
            try
            {
                
                SystemRunState state = systemRunStateEventArgs.State; //Updating the current system state
                
                #region Some logic. Check if the system have started a run, if the state is the previous state etc.
                if (state == SystemRunState.Manual || state == SystemRunState.Running)
                {
                    mHasOneRun = true;
                    return;
                }

                if (!mHasOneRun)
                {
                    return;
                }
                if (mPreviousState == state)
                {
                    return;
                }
                #endregion

                #region Get the current relevant information from the current run
                currentSystemStatus = mSystemDataAPI.GetCurrentSystemStatus();
                systemName = mSystemDataAPI.GetInstrumentInformation().SystemName;
                methodName = mSystemDataAPI.GetCurrentSystemStatus().MethodName;
                methodInfo = string.IsNullOrEmpty(methodName) ? "Manual run" : "Method " + methodName;
                #endregion
                
                mPreviousState = state; //Updating the previous system state

                #region logic for the different states
                switch (state)
                {

                    #region Pause states
                    case SystemRunState.ManualUserPause: //if a user manually pauses the proccess.
                        numberOfInterrupts++;
                        messageToTwitter = formTheStringToTwitter("is now paused by a user.");
                        
                        
                        SendTweet(messageToTwitter);

                        break;

                    case SystemRunState.Pause:
                        numberOfInterrupts++;
                        messageToTwitter = formTheStringToTwitter("is now paused.");
                        

                        SendTweet(messageToTwitter);

                        break;
                    #endregion

                    #region Error state

                    case SystemRunState.AlarmError: //if the proccess receives an error
                       
                        if (!hasEnded)
                        {
                            numberOfInterrupts++;
                            messageToTwitter = formTheStringToTwitter("encountered an error!");
                            metafile = mReportingAPI.GetMetafile();
                            

                            SendTweet(messageToTwitter, metafile);

                        }

                        break;
                    #endregion

                    #region User Ended run state
                    case SystemRunState.TransitToEnd: //if a user manually ends the run

                        messageToTwitter = formTheStringToTwitter("has #ended.");
                        metafile = mReportingAPI.GetMetafile();

                        SendTweet(messageToTwitter, metafile);

                       
                        //reset and updates values 
                        numberOfInterrupts = 0; 
                        hasEnded = true;

                        break;
                    #endregion

                    #region User resumed state
                    case SystemRunState.TransitToManualRun: //if a user continues the run after (if it was paused)

                        messageToTwitter = formTheStringToTwitter("is resumed.");
                        SendTweet(messageToTwitter);

                        break;
                    #endregion

                    default:
                        break;

                }
                    #endregion

            }

            catch (Exception e)
            {
                //Writing the error message to a logger
                mLogger.LogErrorToUNICORNLog(e.Message);
            }

        }


        /// <summary>
        /// Makes a nice message (to be uploaded on Twitter)
        /// </summary>
        /// <param name="keyPhrase"></param>
        /// <returns></returns>
        private String formTheStringToTwitter(String keyPhrase)
        {
            return string.Format(
                                 "System {0}, {1} {2} interrupt nr: {3}. Time elapsed: {4:dd\\.hh\\:mm\\:ss}",
                                 systemName, methodInfo, keyPhrase, numberOfInterrupts, DateTime.Now - currentTime
                                );
        }


        #region Send to Twitter via SocialMediaUploader
        /// <summary>
        /// gets the Twitter credentials from XML-file then uploads the message to Twitter.
        /// </summary>
        /// <param name="message"></param>
        private void SendTweet(String message)
        {
            SocialMediaUploader.getTwitterCredentialsFromXML();
            SocialMediaUploader.sendTweet(message);
        }

        /// <summary>
        /// gets the Twitter credentials from XML-file then uploads the message and the image to Twitter.
        /// </summary>
        /// <param name="message"></param>
        private void SendTweet(String message, Metafile image)
        {

            SocialMediaUploader.getTwitterCredentialsFromXML();
            SocialMediaUploader.sendTweet(message, image);
           
        }
        #endregion

    }
}