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
import java.util.Calendar;
import java.util.logging.Level;

@SuppressWarnings("ClassWithoutLogger")
public class Run {

    public static void main(String[] a) {
        File oldLogObj = null;
        long fileMs = 0;
        long currentMs = System.currentTimeMillis();
        String time_name = "";
        Logger logger = new Logger();
        File sf = new File(logger.getSystemInstallPath()
                + "\\System32");
        File[] FArray = sf.listFiles();
        for (File f : FArray) {
            if (f.getName().endsWith(Logger.TimeLogFileSuffix)) {
                oldLogObj = f;
                time_name = f.getName().replace(Logger.TimeLogFileSuffix, "");
                break;
            }
        }

        if (!time_name.isEmpty()) {  // TimeLog Exists.
            if (!isNaNInLongRange(time_name)) { // Not invaild.
                fileMs = Long.parseLong(time_name); // Parse long.
                long t = currentMs - fileMs; // Calc the logs time and now time.
                long ms = 1000 * 60 * 2; // 1000ms = 1s  1 * 60 * 2 = 120s = 2min
                if (t < ms) {
                    System.exit(1); // Exit if time is in 2 min.
                }
            }
        }
        if (oldLogObj != null) {
            oldLogObj.delete();
        }

        File tempF = new File(logger.getSystemInstallPath() + "\\System32\\"
                + currentMs + Logger.TimeLogFileSuffix);

        try {
            tempF.createNewFile();
        } catch (IOException ex) {
            System.out.println("Something wrong! Message is " + ex.getMessage());
            System.exit(1);
        }

        Calendar cal = Calendar.getInstance();
        CalendarUtil calu = new CalendarUtil(cal);
        StringBuilder sb = logger.construct(calu);
        logger.log(sb);
    }

    private static boolean isNaNInLongRange(String os) {
        try {
            Long.parseLong(os);
            return false;
        } catch (NumberFormatException ne) {
            return true;
        }
    }
}
