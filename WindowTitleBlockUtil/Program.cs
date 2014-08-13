using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace ACWindowTitleBlockUtil
{
    class Program : ServiceBase
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

        public void findTitle()
        {
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    // p.WaitForInputIdle();
                    if (p.MainWindowTitle.Contains("nba"))
                    {
                       p.Kill();
                    }
                    else
                    {
                        continue;
                    }
                    Thread.Sleep(2000);
                }
            }

        }

        protected override void OnStart(string[] args)
        {
            Thread t = new Thread(new ThreadStart(findTitle));
            t.IsBackground = true;
            t.Name = "Find Thread";
            t.Start();
            // TODO
        }
    }
}
