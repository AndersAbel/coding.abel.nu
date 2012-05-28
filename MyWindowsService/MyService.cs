using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace MyWindowsService
{
    public partial class MyService : ServiceBase
    {
        StreamWriter log = new StreamWriter("c:\\temp\\myservice.log", true);

        public MyService()
        {
            InitializeComponent();

            Disposed += Dispose;
        }

        protected override void OnStart(string[] args)
        {
            log.WriteLine("{0}: MyService Started!", DateTime.Now);
            log.Flush();
        }

        protected override void OnStop()
        {
            log.WriteLine("{0}: MyService Stopped!", DateTime.Now);
            log.Flush();
        }

        void Dispose(object sender, EventArgs e)
        {
            log.Dispose();
        }
    }
}
