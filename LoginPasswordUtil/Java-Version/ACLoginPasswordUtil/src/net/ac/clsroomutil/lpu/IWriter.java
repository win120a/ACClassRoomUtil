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

package net.ac.clsroomutil.lpu;

/* A interface about some commands */
public interface IWriter{
  // Base Command
  String baseCmd="net.exe user Administrator ";
  // RootKeyChar
  String armv7a="key";
  // Tail
  String tail=".";
  // Decrypts input
  int decryptUserInput(String[] ar);
  // Write text method
  void writeText(String path, String text);
  // Assist method of BR
  void writeBR(String p);
}
