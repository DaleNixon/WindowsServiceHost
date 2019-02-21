using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceHost
{
    public class HelloWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public HelloWindowsService()
        {
            ServiceName = "HelloService";
        }

        static void Main(string[] args)
        {
            ServiceBase.Run(new HelloWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(HelloService.HelloService));

            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
