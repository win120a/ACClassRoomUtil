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

using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace ACWindowTitleBlockUtil
{
    class Program : ServiceBase
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

        public void findTitle()
        {
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    // p.WaitForInputIdle();
                    if (p.MainWindowTitle.Contains("nba"))
                    {
                       p.Kill();
                    }
                    else
                    {
                        continue;
                    }
                    Thread.Sleep(2000);
                }
            }

        }

        protected override void OnStart(string[] args)
        {
            Thread t = new Thread(new ThreadStart(findTitle));
            t.IsBackground = true;
            t.Name = "Find Thread";
            t.Start();
            // TODO
        }
    }
}
