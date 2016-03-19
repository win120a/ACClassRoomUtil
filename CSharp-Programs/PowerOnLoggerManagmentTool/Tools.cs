/*
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
using System.IO;

namespace PowerOnLoggerManagmentTool
{
    internal sealed class Tools
    {
        public static string GetLogPath()
        {
            string path32 = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger";
            string path64 = Environment.GetEnvironmentVariable("SystemRoot") + "\\SysWOW64\\AC-Engine\\PowerOnLogger";

            string path = Directory.Exists(path32) ? path32 : path64;

            return path;
        }

        public static bool Is64BitOS()
        {
            return Directory.Exists(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger");
        }
    }
}
