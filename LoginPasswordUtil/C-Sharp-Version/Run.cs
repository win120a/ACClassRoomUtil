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

/*
-> ACLoginPasswordUtil.exe
This is my first draft of this (C# version), it may not pass the build.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACLoginPasswordUtil;
using System.Diagnostics;


namespace ACLoginPasswordUtil
{
    class Run
    {
        int decrypt(String[] originalArgs)
        {
            int first = Int32.Parse(originalArgs[0]);
            int second = Int32.Parse(originalArgs[1]);
            int result = first + second;
            return result;
        }


        public static void Main(String[] a)
        {
            String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
            Run thisInstance = new Run();
            Resources resClass = new Resources();
            int pswInt = thisInstance.decrypt(a);
            if (pswInt > 1 && !(pswInt > 5)) // The value check.
            {
              StringBuilder sBuilder = new StringBuilder();
              sBuilder.Append(sysPath);
              sBuilder.Append("\\System32\\");
              sBuilder.Append(resClass.baseCmd);
              sBuilder.Append(resClass.netCmd);
              String cmdText = sBuilder.ToString();
              sBuilder.Clear();
              sBuilder.Append(resClass.armv7a);
              sBuilder.Append(pswInt);
              String pswText = sBuilder.ToString();
              sBuilder.Clear();
              sBuilder.Append(cmdText);
              sBuilder.Append(pswText);
              Process.Start(sBuilder.ToString());
            }
        }
    }
}
