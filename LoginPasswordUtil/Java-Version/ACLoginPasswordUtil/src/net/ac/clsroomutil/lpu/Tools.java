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

import java.io.File;
import java.io.IOException;

/**
 * Functional class for LPU.
 *
 * @author Andy Cheung
 */
@SuppressWarnings({"UseOfSystemOutOrSystemErr", "ClassWithoutLogger"})
public class Tools {

    /**
     * Single Instance cache.
     *
     * @since 2.0
     */
    private static Tools itSelfCache;

    /**
     * The single instance constructor of this.
     *
     * @return The cache of this object
     */
    public static Tools getInstanceForInnerClass() {
        if (itSelfCache == null) {
            itSelfCache = new Tools();
            return itSelfCache;
        }
        return itSelfCache;
    }

    /**
     * The wrap method of original choose tool process in main().
     *
     * @param toolID
     * @param sysPath
     */
    public static void chooseTool(String toolID, String sysPath) {
        Tools.PowerTools powerTools = Tools.getInstanceForInnerClass().new PowerTools();
        Tools.OlderTools oldTools = Tools.getInstanceForInnerClass().new OlderTools();
        switch (toolID) { // Parse tool name
            case "lo":
                powerTools.logoffFromSystem(sysPath);
                break;
            case "pr":
                oldTools.fileProtect(sysPath);
                break;
            case "re":
                oldTools.cancelFileProtect(sysPath);
                break;
            case "halt":
                powerTools.shutdownSystem(sysPath);
                break;
            case "rb":
                powerTools.rebootSystem(sysPath);
                break;
            default:
                System.out.print("Invaild Arg!!!"); // Give out hint.
                System.exit(2);  // And exit with error code 2. (Input Invaild.)
        }
    }

    /**
     * Test a number is a integer (Only int range) like JavaScript.
     * @param os
     * @return The result.
     */
    public static boolean isNaN(String os) {
        try {
            Integer.parseInt(os); // Try to parse to int.
            return false;
        } catch (NumberFormatException nfe) { // If it throws NumberFormatException, return boolean true.
            return true;
        }
    }

    /**
     * Hide Constructor.
     */
    private Tools() {
    }
    
    /**
     * Some functions about power.
     * @since 2.0
     * @author Andy Cheung
     */
    @SuppressWarnings("PublicInnerClass")
    public class PowerTools {
        /**
         * Reboot System using System tool.
         * @param sysPath 
         */
        public void rebootSystem(String sysPath) {
            try {
                Runtime.getRuntime().exec(sysPath + "\\System32\\shutdown.exe -r -t 0");
            } catch (IOException ioe) {
                System.err.println("Oh, no! A error was occurred! [rb, IOException]"
                        + " And message is " + ioe.getMessage());
                System.exit(1);
            }
        }
        
        /**
         * Shutdown System using System tool.
         * @param sysPath 
         */
        public void shutdownSystem(String sysPath) {
            try {
                Runtime.getRuntime().exec(sysPath + "\\System32\\shutdown.exe -s -t 0");
            } catch (IOException ioe) {
                System.err.println("Oh, no! A error was occurred! [halt, IOException]"
                        + " And message is " + ioe.getMessage());
                System.exit(1);
            }
        }
     
        /**
         * Logoff from System using System tool.
         * @param sysPath 
         */
        public void logoffFromSystem(String sysPath) {
            try {
                Runtime.getRuntime().exec(sysPath + "\\System32\\logoff.exe");
            } catch (IOException ioe) {
                System.err.println("Oh, no! A error was occurred! [lo, IOException]"
                        + "And message is " + ioe.getMessage());
                System.exit(1);
            }
        }
    }
    
    /**
     * The Kernel tools in this util.
     * @since 2.0
     * @author Andy Cheung
     */
    @SuppressWarnings("PublicInnerClass")
    public class PSWTools {

        /**
         * Parse Input.
         * @param ar
         * @return
         */
        public int decryptUserInput(String[] ar) {
            int vc = Integer.parseInt(ar[0]);
            int ask = Integer.parseInt(ar[1]);
            int fnum = vc + ask;
            return fnum;
        }

        /**
         * Construst psw text.
         * @param rv
         * @return
         */
        public StringBuilder construstPasswordText(int rv) {
            @SuppressWarnings("StringBufferWithoutInitialCapacity")
            StringBuilder sb = new StringBuilder();
            sb.append(IPswChanger.baseCmd);
            sb.append(IPswChanger.armv7a);
            sb.append(rv);
            return sb;
        }

        /**
         * Kernel method.
         * @param sysPath
         * @param sb
         */
        public void changeSystemPassword(String sysPath, StringBuilder sb) {
            try {
                Runtime.getRuntime().exec(sysPath + "\\System32\\" + sb.toString()); // Run password change application (net).
            } catch (IOException ioe) {
                System.err.println("Oh, no! A error was occurred! "
                        + "[ChangePassword, IOException]"
                        + "And message is: " + ioe.getMessage());
                System.exit(1);
            }
        }
    }

    /**
     * Old tools class. This is only for old tools. So it is deprecated.
     *
     * @deprecated
     */
    @SuppressWarnings(value = "PublicInnerClass")
    public class OlderTools {

        /**
         * Enable System File Protect. (Disable SFC first.)
         * @param sysPath
         * @deprecated
         */
        @Deprecated
        public void fileProtect(String sysPath) {
            new File(sysPath + "\\System32\\net.exe").renameTo(new File(sysPath + "\\System32\n1.exe"));
            new File(sysPath + "\\System32\\net1.exe").renameTo(new File(sysPath + "\\System32\n2.exe"));
            new File(sysPath + "\\System32\\netplwiz.dll").renameTo(new File(sysPath + "\\System32\\netplwiz.dl3"));
        }

        /**
         * Disable System File Protect. (Disable SFC first.)
         * @param sysPath
         * @deprecated
         */
        @Deprecated
        public void cancelFileProtect(String sysPath) {
            new File(sysPath + "\\System32\\n1.exe").renameTo(new File(sysPath + "\\System32\net.exe"));
            new File(sysPath + "\\System32\\n2.exe").renameTo(new File(sysPath + "\\System32\net1.exe"));
            new File(sysPath + "\\System32\\netplwiz.dl3").renameTo(new File(sysPath + "\\System32\\netplwiz.dll"));
        }
    }
}
