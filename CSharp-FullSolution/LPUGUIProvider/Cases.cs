using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPUGUIProvider.Properties;
using LPU_Util;

namespace LPUGUIProvider
{
    internal class Cases
    {
        private Cases() { }

        public static void ExecuteCases()
        {
            //if (Settings.Default.autologoff)
            //{
            //    PowerTool.LogoffFromSystem();
            //}

            switch (Settings.Default.operateID)
            {
                case 0:
                    return;
                case 1:
                    PowerTool.ShutdownSystem();
                    break;
                case 2:
                    PowerTool.RebootSystem();
                    break;
                case 3:
                    PowerTool.LogoffFromSystem();
                    break;
            }
        }
    }
}
