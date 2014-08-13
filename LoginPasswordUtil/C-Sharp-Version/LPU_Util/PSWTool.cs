using ACLoginPasswordUtil;
using System;
using System.Text;
using System.Diagnostics;

namespace LPU_Util
{
    public class PSWTool
    {
        public StringBuilder ConstructCommandText(String sysPath, Resources resClass)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(sysPath);
            sBuilder.Append("\\System32\\");
            sBuilder.Append(resClass.baseCmd);
            return sBuilder;
        }

        public StringBuilder ConstructArgText(StringBuilder sBuilder, Resources resClass, int pswInt)
        {
            sBuilder.Clear();
            sBuilder.Append(resClass.netCmd);  // arg1 " user ..."
            sBuilder.Append(resClass.armv7a); // KeyChar
            sBuilder.Append(pswInt); // Int
            return sBuilder;
        }

        public int DecryptUserInput(String[] originalArgs)
        {
            int first = Int32.Parse(originalArgs[0]);
            int second = Int32.Parse(originalArgs[1]);
            int result = first + second;
            return result;
        }
        public void ChangeSystemPassword(String sysPath, Resources resClass, int pswInt)
        {
            StringBuilder sBuilder = ConstructCommandText(sysPath, resClass);
            String commandText = sBuilder.ToString(); // Path to net
            StringBuilder argBuilder = ConstructArgText(new StringBuilder(), resClass, pswInt);
            String optionText = argBuilder.ToString();
            ProcessStartInfo psi = new ProcessStartInfo(commandText, optionText);
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(psi);
        }
    }
}
