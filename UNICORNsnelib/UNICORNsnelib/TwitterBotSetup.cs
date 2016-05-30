using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Reflection;

namespace UNICORNsnelib
{
    public partial class TwitterBotSetup : Form
    {

        #region Global variables
        /// <summary>
        /// Not the passwords for encryption and decryption
        /// </summary>
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        
        #endregion

        /// <summary>
        /// Initializing the TwitterBotSetup
        /// </summary>
        public TwitterBotSetup()
        {
            
            InitializeComponent();
        }


        /// <summary>
        /// Reads the values from a xml document and sets the textboxes accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitterBotSetup_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(getXMLpath());
                String XMLpath = getXMLpath();
                //String XMLpath = "C:\\Program Files (x86)\\GE Healthcare\\UNICORN\\UNICORN 7.0\\bin\\Extensions\\UNICORNSocialNetworkExtension\\Credentials.xml";
                XmlDocument xmldoc = new XmlDocument();
                FileStream fs = new FileStream(XMLpath, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                XmlNodeList xmlnode;
                xmlnode = xmldoc.GetElementsByTagName("Credentials");
                String ConKey = Decrypt(xmlnode[0].ChildNodes.Item(0).InnerText.Trim());
                String ConSecret = Decrypt(xmlnode[0].ChildNodes.Item(1).InnerText.Trim());
                String AccToken = Decrypt(xmlnode[0].ChildNodes.Item(2).InnerText.Trim());
                String AccSecret = Decrypt(xmlnode[0].ChildNodes.Item(3).InnerText.Trim());
                fs.Close();

                ConsumerKey.Text = ConKey;
                ConsumerSecret.Text = ConSecret;
                AccessToken.Text = AccToken;
                AccessTokenSecret.Text = AccSecret;
            }
            catch (Exception)
            {

                
            }

            
        }


        #region Encryption and Decryption
        /// <summary>
        /// Encrypts a string using a algorithm 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Decrypts a encrypted string using a algorithm 
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes( 256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        #endregion


        #region TBR (To Be Removed)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Reads the values from the four textboxes and updates the values in the XML document with thoose four values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Apply_Click(object sender, EventArgs e)
        {
            String AccTok = AccessToken.Text;
            String AccTokSec = AccessTokenSecret.Text;
            String ConKey = ConsumerKey.Text;
            String ConSec = ConsumerSecret.Text;

            
            String XMLpath = getXMLpath();
            // String XMLpath = "C:\\Program Files (x86)\\GE Healthcare\\UNICORN\\UNICORN 7.0\\bin\\Extensions\\UNICORNSocialNetworkExtension\\Credentials.xml";
            XmlTextWriter writer = new XmlTextWriter(XMLpath, Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            createNode(AccTok, AccTokSec, ConKey,ConSec, writer);
            writer.WriteEndDocument();
            writer.Close();


            MessageBox.Show("Credentials has been updated!", "Updated");
        }


        /// <summary>
        /// Get the path for the XML file where the credentials is located or where they will be created
        /// </summary>
        /// <returns></returns>
        public static string getXMLpath()
        {
                /*
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.Combine(Path.GetDirectoryName(path),"Credentials.xml");*/

            
            String fullPath = Assembly.GetAssembly(typeof(Assembly)).Location;

            return Path.Combine(Path.GetDirectoryName(fullPath), "Credentials.xml");
            

        }

        /// <summary>
        /// Encrypts the strings and writes via the writer to an XML document
        /// </summary>
        /// <param name="AccTok"></param>
        /// <param name="AccTokSec"></param>
        /// <param name="ConKey"></param>
        /// <param name="ConSec"></param>
        /// <param name="writer"></param>
        private void createNode(string AccTok, string AccTokSec, string ConKey, string ConSec, XmlTextWriter writer)
        {
            writer.WriteStartElement("Credentials");
            writer.WriteStartElement("ConsumerKey");
            writer.WriteString(Encrypt(ConKey));
            writer.WriteEndElement();
            writer.WriteStartElement("ConsumerSecret");
            writer.WriteString(Encrypt(ConSec));
            writer.WriteEndElement();
            writer.WriteStartElement("AccessToken");
            writer.WriteString(Encrypt(AccTok));
            writer.WriteEndElement();
            writer.WriteStartElement("AccessTokenSecret");
            writer.WriteString(Encrypt(AccTokSec));
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by: Tobias Andersson, Albin Sundqvist, Joel Åstrand");
        }

        private void howToGetCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://apps.twitter.com/");

            }
            catch
            {
                
            }
        }
    }
}
