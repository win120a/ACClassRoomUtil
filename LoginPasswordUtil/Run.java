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

import java.io.*;

/* The Main Class */
public class Run implements IWriter{
  // Implement the interface
  public int decrypt(String[] ar){
    int vc = Integer.parseInt(ar[0]);
    int ask = Integer.parseInt(ar[1]);
    int fnum = vc + ask;
    return fnum;
  }

  // For some tools.
  public void execute(int code){
    String sysPath = System.getenv("SystemRoot"); // Get System install path.
    switch(code){ // Get tool number
        case 0: // lo
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\logoff.exe");
          }
          catch(IOException ioe){}
          break;
        case 1: // pr
          writeText("C:\\t.cmd", "ren %systemroot%\\net.exe n1.exe");
          writeBR("C:\\t.cmd");
          writeText("C:\\t.cmd", "ren %systemroot%\\net1.exe n2.exe");
          writeBR("C:\\t.cmd");
          writeText("C:\\t.cmd", "ren %systemroot%\\netplwiz.dll netplwiz.dl3");
          writeBR("C:\\t.cmd");
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\cmd.exe " + "C:\\t.cmd");
          }
          catch(IOException ioe){}
          break;
        case 2: // re
          writeText("C:\\t.cmd", "ren %systemroot%\\n1.exe net.exe");
          writeBR("C:\\t.cmd");
          writeText("C:\\t.cmd", "ren %systemroot%\\n2.exe net1.exe");
          writeBR("C:\\t.cmd");
          writeText("C:\\t.cmd", "ren %systemroot%\\netplwiz.dl3 netplwiz.dll");
          writeBR("C:\\t.cmd");
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\cmd.exe " + "C:\\t.cmd");
          }
          catch(IOException ioe){}
          break;
        default: // otherwise, nothing
          return;
    }
  }

  // A method to write a batch file.
  public void writeText(String path,String text){
    File tBatchF = new File(path);

    FileOutputStream tBatchStream = null;
    try{
      tBatchStream = new FileOutputStream(tBatchF);
    }
    catch(FileNotFoundException fnfe){
    }

    PrintStream tBatchPStream = null;
    try{
      tBatchPStream = new PrintStream(tBatchStream);
    }
    catch(NullPointerException npe){
    }

    tBatchPStream.append(text);
    tBatchPStream.flush();
    tBatchPStream.close();
  }

  // Assist Method of writeText().
  public void writeBR(String p){
    writeText(p, "\n");
  }

  // Main Method.
  public static void main(String[] a){
    // Get a copy of this class to run non-static methods.
    Run thisInstance = new Run();
    if(a[0] == "x" && a[1] == "x"){ // Open tool gate
      switch(a[3]){
        case "lo":
          thisInstance.execute(0);
          break;
        case "pr":
          thisInstance.execute(1);
          break;
        case "re":
          thisInstance.execute(2);
          break;
        default:
          System.out.print("Invaild Arg!!!");
      }
    }
    else{ // Change Password Block
      int rv = thisInstance.decrypt(a);
      if(rv >= 1 && !(rv > 5)){
        StringBuffer sb = new StringBuffer();
        sb.append(IWriter.baseCmd);
        sb.append(IWriter.armv7a);
        sb.append(rv);
        thisInstance.writeText("C:\\t.cmd", sb.toString()); // Make a batch file to change password.
        String sysPath = System.getenv("SystemRoot");
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\cmd.exe " + "C:\\t.cmd"); // Run it!
          }
          catch(IOException ioe){}
      }
    }
  }
}
