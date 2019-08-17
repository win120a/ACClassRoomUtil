/*
   Copyright (C) 2011-2019 Andy Cheung

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using ACLibrary.Collection;
using ACLibrary.Crypto.MixCryptSeries;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ACCVF
{
    public class ACCommonVerify : IVerifier
    {
        #region Verify String Method Zone
        public string GetFirstVerifyInstructionString()
        {
            return "据约定输入验证字符：";
        }

        public string GetSecondVerifyInstructionString()
        {
            return "联网验证字符密码：";
        }
        #endregion

        #region Core methods
        public string Hints()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DNS地址有：");

            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, List<string>> dnsd = NICInfoHelper.GetPrivateNICDNSAndMACDictonary();
                ACDictionary<string, List<string>> adnsd = (ACDictionary<string, List<string>>)ACDictionary<string, List<string>>.SystemCollection2ACCollection(dnsd);

                if (adnsd.Exists(macAddr))
                {
                    int i = 0;
                    foreach (string s in adnsd[macAddr])
                    {
                        sb.Append(s);
                        if (i != ((adnsd.Count) - 1))
                        {
                            sb.Append(",");
                        }
                        i++;
                    }
                }
            }

            sb.Append('\n');
            sb.Append('\n');
            sb.Append("DHCP地址有：");
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, string> dhcpd = NICInfoHelper.GetPrivateNICDHCPAndMACDictonary();
                ACDictionary<string, string> adhcpd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(dhcpd);
                if (adhcpd.Exists(macAddr))
                {
                    sb.Append(adhcpd[macAddr]);
                }
            }

            sb.Append('\n');
            sb.Append('\n');
            sb.Append("IP地址有：");
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, string> ipd = NICInfoHelper.GetPrivateNICIPAndMACDictonary();
                ACDictionary<string, string> aipd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(ipd);
                if (aipd.Exists(macAddr))
                {
                    sb.Append(aipd[macAddr] + ",");
                }
            }

            return sb.ToString();
        }

        public bool VerifyValue(string value1, string value2)
        {
            // If the value is invaild, return false.
            if (value1 == "" || !(value1.Contains(".")) || value2 == "")
            {
                return false;
            }

            // Flags
            bool dhcp = false;
            bool dns = false;
            bool ip = false;
            bool olv = false;

            // DHCP.IP.DNS.VerifyNum

            // Split them into arrays.
            string[] values = value1.Split('.');

            // Check length of the array.
            if (values.Length != 4)
            {
                MessageBox.Show("非法验证字符！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // MessageBox.Show("IP地址错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verify DHCP
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                // Get address collection.
                Dictionary<string, string> dhcpd = NICInfoHelper.GetPrivateNICDHCPAndMACDictonary();
                ACDictionary<string, string> adhcpd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(dhcpd);

                if (adhcpd.Exists(macAddr))  // Get addresses.
                {
                    string[] s = adhcpd[macAddr].Split('.');

                    if (s[0] == values[0])  // Verify the dhcp to the value1.
                    {
                        dhcp = true;
                    }
                }
            }

            if (!dhcp)         // Quit the method if the DHCP Value is wrong. (To make the app faster.)
            {
                return false;
            }

            // Verify DNS.
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, List<string>> dnsd = NICInfoHelper.GetPrivateNICDNSAndMACDictonary();
                ACDictionary<string, List<string>> adnsd = (ACDictionary<string, List<string>>)ACDictionary<string, List<string>>.SystemCollection2ACCollection(dnsd);

                if (adnsd.Exists(macAddr))
                {
                    foreach (string s in adnsd[macAddr])
                    {
                        string[] sv = s.Split('.');

                        if (sv[0] == values[2])  // Verify the dns to the value1.
                        {
                            dns = true;  // Set flag to true if passed test.
                        }
                    }
                }
            }

            if (!dns)
            {
                return false;
            }

            // Verify IP
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, string> ipd = NICInfoHelper.GetPrivateNICIPAndMACDictonary();
                ACDictionary<string, string> aipd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(ipd);
                if (aipd.Exists(macAddr))
                {
                    string[] sv = aipd[macAddr].Split('.');

                    if (sv[0] == values[1])  // Verify the ip to the value1.
                    {
                        ip = true;  // Set flag to true if passed test.
                    }
                }
            }

            if (!ip)
            {
                return false;
            }

            // Online Verify Part
            // Get Verify Message.
            string onlineMessage = new WebClient().DownloadString("http://win120a.github.io/api/VChar.txt");

            Mid engine = Mid.Instance;
            StringBuilder TBilder = new StringBuilder();

            try
            {
                TBilder.Append(engine.DecryptString(onlineMessage, value2));   // Secure decrypt it.
            }
            catch (CryptographicException)
            {
                MessageBox.Show("联网验证密码错误！", "提示");
                return false;
            }

            string ds = TBilder.ToString();

            if (values[3] == ds)
            {
                olv = true;   // If equals, set flag to true.
            }

            return dhcp & ip & dns & olv;
        }
        #endregion
    }
}
