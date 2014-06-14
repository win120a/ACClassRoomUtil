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
This is my first draft of this (C# version), it may not pass the build.
*/

using System;
using System.Diagnostics.Process;
using System.Environment;

namespace ACLoginPasswordUtil{
  class Main{
    int decrypt(String[] originalArgs){
      int first = Int32.Parse(originalArgs[0]);
      int second = Int32.Parse(originalArgs[1]);
      int result = first + second;
      return result;
    }

    static void main(String[] a){
      String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
      int pswInt = decrypt(a);
      //Process.Start();
  }
}
