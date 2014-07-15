﻿/*
   Copyright (C) 2011-2014 AC Inc. (Andy Cheung)

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

using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace ACProcessBlockUtil
{
    class PBUService : ServiceBase
    {
        static String[] list;
        PBUService cache;

        public PBUService()
        {
          cache = this;
        }

        public static void kill()
        {
          while (true)
          {
            foreach (String s in PBUService.list)
            {
              Process[] thatProcArray = Process.GetProcessesByName(s);
              if (thatProcArray.Length == 0)
              {
                continue;
              }
              foreach (Process p in thatProcArray)
              {
                p.Kill();
              }
              Thread.Sleep(2000);
            }
          }
        }

        public static void Main(String[] a)
        {
          StreamReader sr;
	  PBUService thisInstance = new PBUService();
	  String userProfile = Environment.GetEnvironmentVariable("UserProfile");
	  String systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
			
	  if(File.Exists(userProfile + "\\ACRules.txt"))
          {
            sr = new StreamReader(userProfile + "\\ACRules.txt");
            String tempLine = sr.ReadToEnd();
            list = tempLine.Split(',');
            sr.Close();
          }
          else
          {
            PBUService.list = new String[] {"iexplore", "360se", "chrome", "firefox", "safari"};
          }
	  ServiceBase.Run(thisInstance);
        }

        protected override void OnStart(String[] a)
        {
          Thread t = new Thread(new ThreadStart(kill));
          t.IsBackground = true;
          t.Start();
        }
    }
}
