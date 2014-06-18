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
          catch(IOException ioe){
            System.err.println("Oh, no! A error was occurred! [lo, IOException]");
            System.exit(1);
          }
          break;
        case 1: // pr
          new File(sysPath + "\\System32\\net.exe").renameTo(new File(sysPath + "\\System32\n1.exe"));
          new File(sysPath + "\\System32\\net1.exe").renameTo(new File(sysPath + "\\System32\n2.exe"));
          new File(sysPath + "\\System32\\netplwiz.dll").renameTo(new File(sysPath + "\\System32\\netplwiz.dl3"));
          break;
        case 2: // re
          new File(sysPath + "\\System32\\n1.exe").renameTo(new File(sysPath + "\\System32\net.exe"));
          new File(sysPath + "\\System32\\n2.exe").renameTo(new File(sysPath + "\\System32\net1.exe"));
          new File(sysPath + "\\System32\\netplwiz.dl3").renameTo(new File(sysPath + "\\System32\\netplwiz.dll"));
          break;
        default: // otherwise, nothing
          return;
    }
  }

  // A method to write a batch file.
  // Maybe I don't need it now.
  public void writeText(String path,String text){
    File tBatchF = new File(path);

    FileOutputStream tBatchStream = null;
    try{
      tBatchStream = new FileOutputStream(tBatchF);
    }
    catch(FileNotFoundException fnfe){
      System.err.println("Oh, no! A error was occurred! [writeText.FileOutputStream, FileNotFoundException]");
      System.exit(1);
    }

    PrintStream tBatchPStream = null;
    try{
      tBatchPStream = new PrintStream(tBatchStream);
    }
    catch(NullPointerException npe){
      System.err.println("Oh, no! A error was occurred! [writeText.PrintStream, NullPointerException]");
      System.exit(1);
    }

    tBatchPStream.append(text);
    tBatchPStream.flush();
    tBatchPStream.close();
  }

  // Assist Method of writeText().
  // Ya, also I don't need it now.
  public void writeBR(String p){
    writeText(p, "\n");
  }

  // Main Method.
  public static void main(String[] a){
    // Delete temp batch file if it exists.
    File tempBatch = new File("C:\\t.cmd");
    if(tempBatch.exists()){
      tempBatch.delete(); //Delete the temp batch file
    }

    // Get a copy of this class to run non-static methods.
    Run thisInstance = new Run();
    if(a[0].equals("x") && a[1].equals("x")){ // Open tool gate
      switch(a[2]){ // Parse tool name
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
          System.out.print("Invaild Arg!!!"); // Give out hint.
      }
    }
    else{ // Change Password Block
      int rv = thisInstance.decrypt(a); // Decrypts input value
      if(rv >= 1 && !(rv > 5)){ // To prevent some errors (only classroom private edition,you know ya.)
        StringBuilder sb = new StringBuilder();
        sb.append(IWriter.baseCmd);
        sb.append(IWriter.armv7a);
        sb.append(rv);
        String sysPath = System.getenv("SystemRoot");
        try{
          Runtime.getRuntime().exec(sysPath + "\\System32\\" + sb.toString()); // Run password change application (net).
        }
        catch(IOException ioe){
          System.err.println("Oh, no! A error was occurred! [Main.ChangePassword, IOException]");
          System.exit(1);
        }
      }
    }
    // CLEANUP!
    if(tempBatch.exists()){
      tempBatch.delete(); //Delete the temp batch file
    }
  }
}
