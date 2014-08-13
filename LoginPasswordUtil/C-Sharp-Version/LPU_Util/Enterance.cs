using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPU_Util
{
    public class Enterance
    {
        public void ChooseTool(String toolID)
        {
            switch (toolID)
            {
                case "lo":
                    PowerTool.LogoffFromSystem();
                    break;
                case "halt":
                    PowerTool.ShutdownSystem();
                    break;
                case "rb":
                    PowerTool.RebootSystem();
                    break;
            }
        }
    }
}
