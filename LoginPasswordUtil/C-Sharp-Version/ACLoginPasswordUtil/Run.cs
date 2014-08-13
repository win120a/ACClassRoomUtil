using System;
using System.Diagnostics;
using System.Text;
using LPU_Util;


namespace ACLoginPasswordUtil
{
    class Run
    {
        public static void Main(String[] a)
        {
            Enterance entry = new Enterance();
            PSWTool pt = new PSWTool();
            if (!(a.Length < 2) && !(a.Length > 3))
            {
              if (a[0].Equals("x") && a[1].Equals("x"))
              {
                  entry.ChooseTool(a[2]);
                  return;
              }
              String sysPath = Environment.GetEnvironmentVariable("SystemRoot");
              Resources resClass = new Resources();
              int pswInt = pt.DecryptUserInput(a);
              if (pswInt >= 1 && !(pswInt > 5)) // The value check.
              {
                StringBuilder sBuilder = pt.ConstructCommandText(sysPath, resClass);
                String commandText = sBuilder.ToString(); // Path to net
                StringBuilder argBuilder = pt.ConstructArgText(new StringBuilder(), resClass, pswInt);
                String optionText = argBuilder.ToString();
                pt.ChangeSystemPassword(sysPath, resClass, pswInt);
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
