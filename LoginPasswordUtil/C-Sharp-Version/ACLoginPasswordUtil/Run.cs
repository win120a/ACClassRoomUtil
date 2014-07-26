using System;
using System.Diagnostics;
using System.Text;


namespace ACLoginPasswordUtil
{
    class Run
    {
        public static void Main(String[] a)
        {
            Tool.PSWTool pt = new Tool.PSWTool();
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
              int pswInt = pt.DecryptUserInput(a);
              if (pswInt >= 1 && !(pswInt > 5)) // The value check.
              {

                StringBuilder sBuilder = pt.ConstructCommandText(sysPath, resClass);
                String commandText = sBuilder.ToString(); // Path to net
                StringBuilder argBuilder = pt.ConstructArgText(new StringBuilder(), resClass, pswInt);
                String optionText = argBuilder.ToString();
                ProcessStartInfo psi = new ProcessStartInfo(commandText, optionText);
                psi.UseShellExecute = false;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
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
