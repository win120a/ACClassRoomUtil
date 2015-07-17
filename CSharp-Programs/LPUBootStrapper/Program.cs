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

// NOT FINISH YET!

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LPUBootStrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cui = false;
            bool gui = false;

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Console.WriteLine(path);

            if (!Directory.Exists(path + "\\cui"))
            {
                cui = true;
            }

            if (!Directory.Exists(path + "\\gui"))
            {
                gui = true;
            }

            bool sc = false;
            bool sg = false;

            foreach (string s in args)
            {
                if (s == "/cui")
                {
                    sc = true;
                }

                if (s == "/gui")
                {
                    sg = true;
                }
            }

            if (sc && sg)
            {
                Console.WriteLine("Invaild Options!");
                return;
            }

            if ((gui & sg) || (cui & sc))
            {
                Console.WriteLine("Application doesn't exist.");
                return;
            }

            if (sg)
            {
                Process.Start(path + "\\gui\\LPU_GUI.exe");
                return;
            }

            if (sc)
            {
                Console.WriteLine("Enter DB Key:");
                string dbKey = Console.ReadLine();
                ProcessStartInfo psi = new ProcessStartInfo(path + "\\cui\\lpu.exe", args[1] + " " + args[2] + " " + dbKey);
                return;
            }
        }
    }
}
