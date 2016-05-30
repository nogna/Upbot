using System;
using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Credentials;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace UNICORNsnelib

{
    public class SocialMediaUploader
    {

        #region Global Variables

        private static String ConsumerKey, ConsumerSecret, AccessToken, accessSecret;
        private static ITwitterCredentials CRED;        //The credentials for the Twitter account
        private static String latestImagePath;
        private static ITweet TWEET;                    //The latest Tweet sent from the program

        #endregion


        #region Set/Get credentials

        /// <summary>
        /// Set the credentials for the Twitter account
        /// </summary>
        /// <param name="consumerkey"></param>
        /// <param name="Consumersecret"></param>
        /// <param name="accesstoken"></param>
        /// <param name="accessecret"></param>
        public static void setTwitterCredentials(String consumerkey, String consumersecret, String accesstoken, String accessecret)
        {
            
            CRED = new TwitterCredentials(consumerkey, consumersecret, accesstoken, accessecret);

        }

        /// <summary>
        /// Reads the credentials from a XML document and sets the credentials after
        /// </summary>
        public static void getTwitterCredentialsFromXML()
        {
           
            String XMLpath = TwitterBotSetup.getXMLpath();
           // String XMLpath = "C:\\Program Files (x86)\\GE Healthcare\\UNICORN\\UNICORN 7.0\\bin\\Extensions\\UNICORNSocialNetworkExtension\\Credentials.xml";
            XmlDocument xmldoc = new XmlDocument();
            FileStream fs = new FileStream(XMLpath, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            XmlNodeList xmlnode;
            xmlnode = xmldoc.GetElementsByTagName("Credentials");
            ConsumerKey = TwitterBotSetup.Decrypt(xmlnode[0].ChildNodes.Item(0).InnerText.Trim());
            ConsumerSecret = TwitterBotSetup.Decrypt(xmlnode[0].ChildNodes.Item(1).InnerText.Trim());
            AccessToken = TwitterBotSetup.Decrypt(xmlnode[0].ChildNodes.Item(2).InnerText.Trim());
            accessSecret = TwitterBotSetup.Decrypt(xmlnode[0].ChildNodes.Item(3).InnerText.Trim());
            fs.Close();
            CRED = new TwitterCredentials(ConsumerKey, ConsumerSecret, AccessToken, accessSecret);

        }
        #region set each cred
        private void setConsumerKey(String consumerkey)
        {
            ConsumerKey = consumerkey;
        }

        private void setConsumerSecret(String consumersecret)
        {
            ConsumerSecret = consumersecret;
        }

        private void setAccessToken(String accesstoken)
        {
            AccessToken = accesstoken;
        }

        private void setAccessSecret(String accessecret)
        {
            accessSecret = accessecret;
        }
        #endregion

        #endregion


        #region Upload content

        /// <summary>
        /// Send text and a image to Twitter and updates TWEET to the latest tweet
        /// </summary>
        /// <param name="TweetText"></param>
        /// <param name="imagepath"></param>
        public static void sendTweet(String TweetText, Metafile image)
        {

            
			byte[] convertedimage = convertImageToByteStream(image);
				
			//acutally sending the tweet
		    var latestTweet = Auth.ExecuteOperationWithCredentials<ITweet>(CRED, () =>
				{

					return Tweet.PublishTweetWithImage(TweetText, convertedimage);
				});

			TWEET = latestTweet;       
			// Check if the tweet as been published and deleting the tmp .png file
			//deleteImageIfTweetPublished(latestTweet);       
        }

        /// <summary>
        /// Send text to Twitter and updates TWEET to the latest tweet
        /// </summary>
        /// <param name="TweetText"></param>
        public static void sendTweet(String TweetText)
        {

            var latestTweet = Auth.ExecuteOperationWithCredentials<ITweet>(CRED, () =>
            {

                return Tweet.PublishTweet(TweetText);
            });

            TWEET = latestTweet;

        }


        /// <summary>
        /// Saves the metafile in the temp folders and reads it after (metafile->byte[])
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static byte[] convertImageToByteStream(Metafile image)
        {
            String convertedImagePath = Path.Combine(Path.GetTempPath(), "graph_from_UNICORN.png");
            image.Save(convertedImagePath);
            latestImagePath = convertedImagePath;
            return File.ReadAllBytes(convertedImagePath);
        }

        #endregion


        /// <summary>
        /// Deletes the tmp image if the latest tweet have been published on Twitter (Not currently used)
        /// </summary>
        /// <param name="latestTweet"></param>
        private static void deleteImageIfTweetPublished(ITweet latestTweet)
        {
            if (latestTweet.IsTweetPublished)
            {
                File.Delete(latestImagePath);
            }

        }

        /// <summary>
        ///  Check if the computer has connection to Twitter (Not currently used)
        /// </summary>
        /// <returns></returns>
        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.twitter.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }

        #region TODO Send commands
        /// <summary>
        /// Command for UNICORN TODO
        /// </summary>
        /// <returns></returns>
        public static String getAnswerFromTweet()
        {
            //Something with our global tweet variable
            return "TODO";
        }

        #endregion
    }
}
