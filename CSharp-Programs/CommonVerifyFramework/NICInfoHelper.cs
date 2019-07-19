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
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ACCVF
{
    internal class NICInfoHelper
    {
        public static Dictionary<string, string> GetPrivateNICIPAndMACDictonary()
        {
            Dictionary<string, string> l = new Dictionary<string, string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var address in n.GetIPProperties().UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(n.GetPhysicalAddress().ToString(), address.Address.ToString());
                    }
                }
            }

            return l;
        }

        public static List<string> GetPrivateNICIPList()
        {
            List<string> l = new List<string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var address in n.GetIPProperties().UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(address.Address.ToString());
                    }
                }
            }

            return l;
        }

        public static List<string> GetPrivateNICMAC()
        {
            List<string> l = new List<string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var i in n.GetIPProperties().UnicastAddresses)
                {
                    if (i.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        l.Add(n.GetPhysicalAddress().ToString());
                    }
                }
            }

            return l;
        }

        public static Dictionary<string, string> GetPrivateNICDHCPAndMACDictonary()
        {
            Dictionary<string, string> l = new Dictionary<string, string>();
            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var e in n.GetIPProperties().DhcpServerAddresses)
                {
                    if (e.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        l.Add(n.GetPhysicalAddress().ToString(), e.ToString());
                    }
                }
            }

            return l;
        }

        public static Dictionary<string, List<string>> GetPrivateNICDNSAndMACDictonary()
        {
            ACDictionary<string, List<string>> d = new ACDictionary<string, List<string>>();
            ACList<string> al = new ACList<string>();

            NetworkInterface[] ns = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in ns)
            {
                foreach (var e in n.GetIPProperties().DnsAddresses)
                {
                    if (e.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        if (al.Exists(n.GetPhysicalAddress().ToString()))
                        {
                            d[n.GetPhysicalAddress().ToString()].Add(e.ToString());
                        }
                        else
                        {
                            d.Add(n.GetPhysicalAddress().ToString(), new List<string>());
                            d[n.GetPhysicalAddress().ToString()].Add(e.ToString());
                        }
                        //l.Add(n.GetPhysicalAddress().ToString(), e.ToString());
                        al.Add(n.GetPhysicalAddress().ToString());
                    }
                }
            }

            return d;
        }
    }
}
