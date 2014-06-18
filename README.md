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


REMINDER of framework (Environment)
============
THESE TOOLS NEED TO INSTALL JAVA ENVIRONMENT and some tools need to install .Net Framework! (.Net Framework 4, JAVA 7 or LATER!!!)<br>

About ACClassRoomUtil
============
A collection use in classroom.<br>
(Windows ONLY! If need, shutdown UAC & Antivirus software)<br>
These programs are licensed with Apache License, you can see it at <a href="https://github.com/win120a/ACClassRoomUtil/blob/master/LICENSE">Here</a>.

Compiling
=========

These releases are wrote by Java + Batch. (And some of release wrote by C#, I don't know how to do it.)

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

System tools and APIs
========
I used system tools to implement some functions, here is a list about this.

LPU
```
net
```

PBU
```
The .Net API (Process.Kill())
```

POL (ON and OFF)
```
The Java API (Calendar, File)
```
