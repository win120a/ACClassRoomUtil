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

package net.ac.clsroomutil.pol;

public interface ILogger {

    String getSystemInstallPath();

    StringBuilder construct(CalendarUtil calu);

    void log(StringBuilder builder);

    String HalfLogPath = "\\System32\\AC-Engine\\PowerOnLogger\\";
    String LogFileName = "ACPOL_";
    String LogFileSuffix = ".aclog";
}
