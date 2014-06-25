/*
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
using NetUtil;

namespace ACProcessBlockUtil
{
    class RuleUpdater
    {
		public static void Main(String[] a){
			/*
				Stop The Service.
			*/
			ServiceController pbuSC = new ServiceController("pbuService");
			pbuSC.stop();

			/*
				Obtain some path.
			*/
			String userProfile = Environment.GetEnvironmentVariable("UserProfile");
			String systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
			
			/*
				Delete Exist file.
			*/
			if(File.Exists(userProfile + "\\ACRules.txt")){
				File.Delete(userProfile + "\\ACRules.txt");
			}
			
			/*
				Download File.
			*/
			NetUtil.writeToFile("http://win120a.github.io/Api/PBURules.txt", userProfile + "\\ACRules.txt");
			
			/*
				Restart the Service.
			*/
			Process.Start(systemRoot + "\\System32\\sc.exe", "start pbuService");
		}
    }
}
