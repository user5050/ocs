using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace OneCoin.Service.Task.Host
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            var sc = new ServiceController {ServiceName = this.serviceInstaller1.ServiceName};

            if (sc.Status != ServiceControllerStatus.Running)
                sc.Start();
        }
    }
}
