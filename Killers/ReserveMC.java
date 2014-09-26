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

import java.net.*;
import java.io.*;

public class ReserveMC{
  public static void main(String[] a){
    System.out.println("Craftbukkit Port Preserve Util");
    System.out.println("(C) 2011-2014 AC Inc.");
    System.out.println();
    new Thread(new PortReserveThread(25565)).start();
    new Thread(new PortReserveThread(1139)).start();
  }
}


class PortReserveThread implements Runnable{
  int port; // This thread's port.
  
  // The TCP Settings Part.
  Socket s; //The Socket, not for use.
  ServerSocket ss; // The ServerSocket.
  
  public void out(String t){
    System.out.println(t);
  }

  public PortReserveThread(int which){
    out("Creating instance of PRT...");
    port = which; // Set port.
    try {
      ss = new ServerSocket(port);  //Get New SS (ServerSocket[TCP]) instance.
      out("Created instance of TCP Socket. This will reserve port " + port);
    } catch (IOException e) {  //Catch the exception.
      System.out.println("Error,Will exit.");
      System.exit(1);
    }
  }
	  
  public void run(){ // Thread method body.
    while(true){ // Unlimited Accept.
      try{
        out("Accepting TCP on " + port);
        s = ss.accept(); // Reserve TCP.
        s.close();
      }
      catch(SocketTimeoutException ste){
        try {
          s.close();
	} catch (IOException e) {
          System.out.println("Error,Will exit.");
          System.exit(1);
	}
      }
      catch(IOException ioe){
	try {
	  s.close();
	} catch (IOException e) {
	  System.out.println("Error,Will exit.");
	  System.exit(1);
	}
      }
      finally{
	try {
	  s.close();
	} catch (IOException e) {
	  System.out.println("Error,Will exit.");
	  System.exit(1);
	}
        s = null;
      }
    }
  }
  
  public void stopSelf(){  //Stop Procress.
    Thread.currentThread().interrupt();
  }
  public int getPort(){
    return port;
  }
}

