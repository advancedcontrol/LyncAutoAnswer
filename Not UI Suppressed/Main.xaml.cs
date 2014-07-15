using System.Windows;
using Microsoft.Lync.Model;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace LyncKiosk
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Minimized;            

            var lync = LyncClient.GetClient();
            lync.ConversationManager.AutoAnswerIncomingVideoCalls(() => Properties.Settings.Default.autoAnswer);
        }
    }
}
