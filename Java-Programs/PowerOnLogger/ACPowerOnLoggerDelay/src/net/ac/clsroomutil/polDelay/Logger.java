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
package net.ac.clsroomutil.polDelay;

import java.io.File;
import java.io.IOException;
import java.util.logging.Level;

public class Logger implements ILogger {

    private static final java.util.logging.Logger LOG = java.util.logging.Logger.getLogger(Logger.class.getName());

    @Override
    public String getSystemInstallPath() {
        return System.getenv("SystemRoot");
    }

    @Override
    public StringBuilder construct(CalendarUtil calu) {
        @SuppressWarnings("StringBufferWithoutInitialCapacity")
        StringBuilder sb = new StringBuilder();
        sb.append(getSystemInstallPath());
        sb.append(ILogger.HalfLogPath);
        sb.append(ILogger.LogFileName);
        sb.append(calu.getYear());
        sb.append("-");
        sb.append(calu.getMonth());
        sb.append("-");
        sb.append(calu.getDay());
        sb.append("_");

        if (!(isBiggerThanOrEqualsTen(calu.getHour()))) {
            sb.append("0");
        }

        sb.append(calu.getHour());
        sb.append("H ");

        if (!(isBiggerThanOrEqualsTen(calu.getMinute()))) {
            sb.append("0");
        }

        sb.append(calu.getMinute());
        sb.append("M ");

        if (!(isBiggerThanOrEqualsTen(calu.getSecond()))) {
            sb.append("0");
        }

        sb.append(calu.getSecond());
        sb.append("S_");
        sb.append(calu.getDayOfWeek());
        sb.append(ILogger.LogFileSuffix);
        return sb;
    }

    private boolean isBiggerThanOrEqualsTen(int value) {
        return value >= 10;
    }

    @Override
    public void log(StringBuilder builder) {
        @SuppressWarnings("UnusedAssignment")
        File fileObj = null;
        @SuppressWarnings("UnusedAssignment")
        File folderObj = null;
        try {
            fileObj = new File(builder.toString());
            folderObj = new File(getSystemInstallPath()
                    + "\\System32\\AC-Engine\\PowerOnLogger");
            if (!(folderObj.exists())) {
                folderObj.mkdirs();
            }
            fileObj.createNewFile();
            LOG.log(Level.INFO, "System Powered On: {0}", folderObj.getAbsolutePath());
        } catch (IOException ioe) {
            System.out.println("Something wrong! Message is " + ioe.getMessage());
            System.exit(1);
        }
    }
}
