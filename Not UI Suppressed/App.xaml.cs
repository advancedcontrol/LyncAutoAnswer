using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Diagnostics;

namespace SuperSimpleLyncKiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Get Reference to the current Process
            Process me = Process.GetCurrentProcess();
            // Check how many total processes have the same name as the current one
            if (Process.GetProcessesByName(me.ProcessName).Length > 1)
            {
                Application.Current.Shutdown();
                return;
            }

            // Ensure only Lync loads
            if (Process.GetProcessesByName("lync").Length <= 0)
            {
                Process.Start("lync");
                System.Threading.Thread.Sleep(10000);
                if (Process.GetProcessesByName("lync").Length <= 0)
                {
                    Application.Current.Shutdown();
                    return;
                }
            }
            else {
                System.Threading.Thread.Sleep(5000);
            }

            base.OnStartup(e);
        }
    }
}
