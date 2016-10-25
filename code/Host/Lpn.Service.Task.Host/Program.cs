using System;
using System.Configuration.Install;
using System.ServiceProcess;
using OneCoin.Service.Bll.Logic.Orders.Task;

namespace OneCoin.Service.Task.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            if (args.Length <= 0)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new Service1(),  
			    };
                ServiceBase.Run(ServicesToRun);
            }
            else if (args[0].ToLower() == "/?" || args[0].ToLower() == "-?")
            {
                Console.WriteLine("/i -u 安装服务");
                Console.WriteLine("/u -u 卸载服务");
                Console.WriteLine("/c -c 控制台执行");
            }
            else if (args[0].ToLower() == "/c" || args[0].ToLower() == "-c")
            {
                Console.WriteLine("服务正在执行。。。");

                OrdersTaskBll.Start();

                Console.ReadLine();
            }
            else if (args[0].ToLower() == "/i" || args[0].ToLower() == "-i")
            {

                try
                {
                    string[] cmdline = { };
                    string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    TransactedInstaller transactedInstaller = new TransactedInstaller();
                    AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);


                    transactedInstaller.Installers.Add(assemblyInstaller);
                    transactedInstaller.Install(new System.Collections.Hashtable());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // 删除服务
            else if (args[0].ToLower() == "/u" || args[0].ToLower() == "-u")
            {
                try
                {
                    string[] cmdline = { };
                    string serviceFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;

                    TransactedInstaller transactedInstaller = new TransactedInstaller();
                    AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                    transactedInstaller.Installers.Add(assemblyInstaller);
                    transactedInstaller.Uninstall(null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
