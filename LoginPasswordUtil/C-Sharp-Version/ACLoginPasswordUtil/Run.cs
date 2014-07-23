using System;
using System.Diagnostics;
using System.Text;


namespace ACLoginPasswordUtil
{
    class Run
    {
        int decrypt(String[] originalArgs)
        {
            int first = Int32.Parse(originalArgs[0]);
            int second = Int32.Parse(originalArgs[1]);
            int result = first + second;
            return result;
        }


        public static void Main(String[] a)
        {
            if (!(a.Length < 2) && !(a.Length > 3))
            {
              if (a[0].Equals("x") && a[1].Equals("x"))
              {
                  switch (a[2])
                  {
                      case "lo":
                          Tool.LogoffFromSystem();
                          break;
                      case "halt":
                          Tool.ShutdownSystem();
                          break;
                      case "rb":
                          Tool.RebootSystem();
                          break;
                  }
                  return;
              }
              String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
              Run thisInstance = new Run();
              Resources resClass = new Resources();
              int pswInt = thisInstance.decrypt(a);
              if (pswInt >= 1 && !(pswInt > 5)) // The value check.
              {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.Append(sysPath);
                sBuilder.Append("\\System32\\");
                sBuilder.Append(resClass.baseCmd);
                String invokeText = sBuilder.ToString(); // Path to net
                sBuilder.Clear();
                sBuilder.Append(resClass.netCmd);  // arg1 " user ..."
                sBuilder.Append(resClass.armv7a); // KeyChar
                sBuilder.Append(pswInt); // Int
                String optionText = sBuilder.ToString();
                ProcessStartInfo psi = new ProcessStartInfo(invokeText, optionText);
                psi.UseShellExecute = false;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
                //Process.Start(invokeText, optionText);
             }
             else
             {
                 Console.WriteLine("INVAILD DAY OF Week Settings (Monday to Friday only for this Edition), If there is some reasons of this, please change it manually.");
             }
          }
          else
          {
              Console.WriteLine("INVAILD ARG LENGTH!");
          }
       }
    }
}
