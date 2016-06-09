﻿/*
   Copyright (C) 2011-2016 AC Inc. (Andy Cheung)

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

namespace LPU_Util
{
    public class PowerTool
    {
        public static void ShutdownSystem()
        {
            string sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\shutdown.exe", "-s -t 0");
        }

        public static void RebootSystem()
        {
            string sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\shutdown.exe", "-r -t 0");
        }

        public static void LogoffFromSystem()
        {
            string sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Process.Start(sysPath + "\\System32\\logoff.exe");
        }
    }
}
