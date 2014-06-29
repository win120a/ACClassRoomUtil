/*
   THIS IS ONLY TO EASY CHANGE, NOT THE PROJECT CODE AT NOW. (I will use in the future.)

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
using System.IO;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Collections;

namespace ACProcessBlockUtil
{
    class Run:ServiceBase
    {
	static SteamReader sr;
	static ArrayList<String> al;
	static String[] list;
		
        public static void kill()
        {
            while (true)
            {
                foreach(String s in Run.list){
                  Process[] thatProcArray = Process.GetProcessesByName(s);
                  if (thatProcArray.Length == 0)
                  {
                      continue;
                  }
                  foreach(Process p in thatProcArray)
                  {
                      p.Kill();
                  }
                  Thread.Sleep(2000);
                }
            }
        }

        public static void Main(String[] a)
        {
	    Run thisInstance = new Run();
	    String userProfile = Environment.GetEnvironmentVariable("UserProfile");
	    String systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
			
	    if(File.Exists(userProfile + "\\ACRules.txt")){
		    Run.ar = new ArrayList<String>();
		    Run.sr = new SteamReader(userProfile + "\\ACRules.txt");
		    while(true){
			    String tempLine = Run.sr.ReadLine();
			    if(tempLine == null){
				    break;
			    }
			    else{
				    Run.ar.Add(tempLine);
			    }
		    }
                    Run.sr.Close();
		    Run.list = Run.ar.ToArray();
	    }
	    else{
		    Run.list = {"iexplore", "360se", "chrome", "firefox", "safari"}
	    }
	    ServiceBase.Run(thisInstance);
        }

        protected override void OnStart(String[] a){
            Thread t = new Thread(new ThreadStart(kill));
            t.IsBackground = true;
            t.Start();
        }
    }
}
