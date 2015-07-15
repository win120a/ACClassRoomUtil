using ACLibrary.Collection;
using ACLibrary.Crypto.MixCryptSeries;
using ACLibrary.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class LargeOperationVerify : Form
    {
        private bool verifed = false;

        public bool Verifed
        {
            get
            {
                return verifed;
            }
        }

        public LargeOperationVerify()
        {
            InitializeComponent();
        }

        private void hint_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DNS地址有：");

            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, List<string>> dnsd = NICInfoHelper.GetPrivateNICDNSAndMACDictonary();
                ACDictionary<string, List<string>> adnsd = (ACDictionary<string, List<string>>) ACDictionary<string, List<string>>.SystemCollection2ACCollection(dnsd);

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

            MessageBox.Show(sb.ToString(), "部分提示");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            verifed = false;
            this.Hide();
            //this.Dispose();
            GC.Collect();
        }

        private void pv_Click(object sender, EventArgs e)
        {
            MessageBox.Show(VerifyValue(textBox1.Text) ? "通过" : "未通过", "结果");
        }

        private bool VerifyValue(string value)
        {
            // If the value is invaild, return false.
            if (value == "" || !(value.Contains(".")))
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
            string[] values = value.Split('.');

            // Verify DHCP
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                // Get address collection.
                Dictionary<string, string> dhcpd = NICInfoHelper.GetPrivateNICDHCPAndMACDictonary();
                ACDictionary<string, string> adhcpd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(dhcpd);
                
                if (adhcpd.Exists(macAddr))  // Get addresses.
                {
                    string[] s = adhcpd[macAddr].Split('.');

                    if (s[0] == values[0])  // Verify the dhcp to the value.
                    {
                        dhcp = true;
                    }
                }
            }

            // Verify DNS.
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, List<string>> dnsd = NICInfoHelper.GetPrivateNICDNSAndMACDictonary();
                ACDictionary<string, List<string>> adnsd = (ACDictionary<string, List<string>>)ACDictionary<string, List<string>>.SystemCollection2ACCollection(dnsd);

                if (adnsd.Exists(macAddr))
                {
                    int i = 0;
                    foreach (string s in adnsd[macAddr])
                    {
                        string[] sv = s.Split('.');

                        if (sv[0] == values[2])  // Verify the dns to the value.
                        {
                            dns = true;  // Set flag to true if passed test.
                        }
                    }
                }
            }

            // Verify IP
            foreach (string macAddr in NICInfoHelper.GetPrivateNICMAC())
            {
                Dictionary<string, string> ipd = NICInfoHelper.GetPrivateNICIPAndMACDictonary();
                ACDictionary<string, string> aipd = (ACDictionary<string, string>)ACDictionary<string, string>.SystemCollection2ACCollection(ipd);
                if (aipd.Exists(macAddr))
                {
                    string[] sv = aipd[macAddr].Split('.');

                    if (sv[0] == values[1])  // Verify the ip to the value.
                    {
                        ip = true;  // Set flag to true if passed test.
                    }
                }
            }

            // Online Verify Part
            // Get Verify Message.
            string onlineMessage = new WebClient().DownloadString("http://win120a.github.io/Api/VChar.txt");
            Mid engine = new Mid();
            string ds = engine.DecryptString(onlineMessage, olp.Text); // Decrypt it.
            if (values[3] == ds)
            {
                olv = true;
            }

            return dhcp & ip & dns & olv;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            verifed = VerifyValue(textBox1.Text);
            this.Hide();
        }
    }
}
