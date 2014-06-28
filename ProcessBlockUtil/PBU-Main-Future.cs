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
	SteamReader sr;
	ArrayList<String> al;
	String[] list;
		
        public static void kill()
        {
            while (true)
            {
                Process[] ieProcArray = Process.GetProcessesByName("iexplore");
                //Console.WriteLine(ieProcArray.Length);
                if (ieProcArray.Length == 0)
                {
                    continue;
                }
                foreach(Process p in ieProcArray){
                    p.Kill();
                }
                Thread.Sleep(2000);
            }
        }

        public static void Main(String[] a)
        {
	    String userProfile = Environment.GetEnvironmentVariable("UserProfile");
	    String systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
			
	    if(File.Exists(userProfile + "\\ACRules.txt")){
		    ar = new ArrayList<String>();
		    sr = new SteamReader(userProfile + "\\ACRules.txt");
		    while(true){
			    String tempLine = sr.ReadLine();
			    if(tempLine == null){
				    break;
			    }
			    else{
				    ar.Add(tempLine);
			    }
		    }
		    list = (String) ar.ToArray();
	    }
	    else{
		    list = {"iexplore", "360se", "qqbrowser"}
	    }
	    ServiceBase.Run(new Run());
        }

        protected override void OnStart(String[] a){
            Thread t = new Thread(new ThreadStart(kill));
            t.IsBackground = true;
            t.Start();
        }
    }
}
