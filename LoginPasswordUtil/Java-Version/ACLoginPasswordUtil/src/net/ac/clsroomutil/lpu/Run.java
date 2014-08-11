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

/* The Main Class */
@SuppressWarnings("ClassWithoutLogger")
public class Run implements IPswChanger {

    // Main Method.
    @SuppressWarnings({"UseOfSystemOutOrSystemErr", "deprecation"})
    public static void main(String[] a) {
        String sysPath = System.getenv("SystemRoot");

        if (a[0].equals("x") && a[1].equals("x")) { // Open tool gate
            Tools.OlderTools oldTools = new Tools().new OlderTools();
            switch (a[2]) { // Parse tool name
                case "lo":
                    Tools.logoffFromSystem(sysPath);
                    break;
                case "pr":
                    oldTools.fileProtect(sysPath);
                    break;
                case "re":
                    oldTools.cancelFileProtect(sysPath);
                    break;
                case "halt":
                    Tools.shutdownSystem(sysPath);
                    break;
                case "rb":
                    Tools.rebootSystem(sysPath);
                    break;
                default:
                    System.out.print("Invaild Arg!!!"); // Give out hint.
            }
        } else if ((!Tools.isNaN(a[0])) && (!Tools.isNaN(a[1]))) { // If not invoke tools, and the values are vaild, into Change Password Block.
            Tools.PSWTools pswt = new Tools().new PSWTools();
            int rv = pswt.decryptUserInput(a); // Decrypts input value
            if (rv >= 1 && !(rv > 5)) { // To prevent some errors (only classroom private edition,you know.)
                @SuppressWarnings("StringBufferWithoutInitialCapacity")
                StringBuilder sb = pswt.construstPasswordText(rv);
                pswt.changeSystemPassword(sysPath, sb);
            } else {
                System.out.print("Invaild Arg!!!"); // Give out hint.
            }
        } else {
            System.out.print("Invaild Arg!!!"); // Give out hint.
        }
    }
}
