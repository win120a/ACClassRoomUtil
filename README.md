<!-- 
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
-->

ACClassRoomUtil
============
REMINDER: THESE TOOLS NEED TO INSTALL JAVA ENVIRONMENT! (JAVA 7 LATER!!!)<br>
(Some Utils uses C#, install .net framework instead.)
A collection use in classroom.<br>
(Windows ONLY! If need, shutdown UAC & Antivirus software)<br>
These programs are licensed with changed Apache License, you can see it at <a href="https://github.com/win120a/ACClassRoomUtil/blob/master/LICENSE">Here</a>.

Compiling
=========

These releases are wrote by Java + Batch.

```Batchfile
set path=%path%;C:\Path\to\Java\bin
Rem If you added Java to PATH, skip this.
cd /d C:\Path\to\Utils\[ToolPath]
javac [File].java
```

Running
========
Use `java Run` to run these tools. (Switch to path of tools first, some tools need to enter another name to implement some functions)
<br><br>
Use `javaw Run` if you want to hidden command window.

System tools
========
I used system tools to implement some functions, there is a list about this.
```
taskkill, hosts (File), net, tasklist
```
