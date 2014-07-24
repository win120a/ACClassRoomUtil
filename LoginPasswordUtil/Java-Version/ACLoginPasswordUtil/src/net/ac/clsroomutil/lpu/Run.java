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
import java.io.*;

/* The Main Class */
public class Run implements IWriter{
  // Implement the interface
  @Override
  public int decryptUserInput(String[] ar){
    int vc = Integer.parseInt(ar[0]);
    int ask = Integer.parseInt(ar[1]);
    int fnum = vc + ask;
    return fnum;
  }

  // For some tools.
  public void executeTools(int code){
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
        case 3: // halt
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\shutdown.exe -s -t 0");
          }
          catch(IOException ioe){
            System.err.println("Oh, no! A error was occurred! [halt, IOException]");
            System.exit(1);
          }
          break;
        case 4: // rb
          try{
            Runtime.getRuntime().exec(sysPath + "\\System32\\shutdown.exe -r -t 0");
          }
          catch(IOException ioe){
            System.err.println("Oh, no! A error was occurred! [rb, IOException]");
            System.exit(1);
          }
          break;  
    }
  }

  // A method to write a batch file.
  // (This my old way) Maybe I don't need it now.
  @Override
  public void writeText(String path,String text){
    File tBatchF = new File(path);
    @SuppressWarnings("UnusedAssignment")
    FileOutputStream tBatchStream = null;
    try{
      tBatchStream = new FileOutputStream(tBatchF);
    }
    catch(FileNotFoundException fnfe){
      System.err.println("Oh, no! A error was occurred! [writeText.FileOutputStream, FileNotFoundException]");
      System.exit(1);
    }
    @SuppressWarnings("UnusedAssignment")
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
  // Also.
  @Override
  public void writeBR(String p){
    writeText(p, "\n");	
  }
  
  // Check Input value.
  public boolean isNaN(String os){
    try{
      Integer.parseInt(os); // Try to parse to int.
      return false;
    }
    catch(NumberFormatException nfe){ // If it throws NumberFormatException, return boolean true.
      return true;
    }
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
          thisInstance.executeTools(0);
          break;
        case "pr":
          thisInstance.executeTools(1);
          break;
        case "re":
          thisInstance.executeTools(2);
          break;
	case "halt":
          thisInstance.executeTools(3);
          break;
        case "rb":
          thisInstance.executeTools(4);
          break;
        default:
          System.out.print("Invaild Arg!!!"); // Give out hint.
      }
    }
    else if((!thisInstance.isNaN(a[0])) && (!thisInstance.isNaN(a[1]))){ // If not invoke tools, and the values are vaild, into Change Password Block.
      int rv = thisInstance.decryptUserInput(a); // Decrypts input value
      if(rv >= 1 && !(rv > 5)){ // To prevent some errors (only classroom private edition,you know.)
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
      else{
        System.out.print("Invaild Arg!!!"); // Give out hint.
      }
    }
    else{
      System.out.print("Invaild Arg!!!"); // Give out hint.
    }
    // CLEANUP!
    if(tempBatch.exists()){
      tempBatch.delete(); //Delete the temp batch file
    }
  }
}