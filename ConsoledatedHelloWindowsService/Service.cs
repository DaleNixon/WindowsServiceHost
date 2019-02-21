using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidatedHelloWindowsService
{
    class ConsolidatedHelloWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public ConsolidatedHelloWindowsService()
        {
            ServiceName = "ConsolidatedHelloService";
        }

        static void Main(string[] args)
        {
            ServiceBase.Run(new ConsolidatedHelloWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(HelloService));

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

    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        string Hello(Person person);
    }

    public class HelloService : IHello
    {
        public string Hello(Person person)
        {
            var middle = " ";

            if (!string.IsNullOrWhiteSpace(person.MiddleName))
            {
                middle = $" {person.MiddleName} ";
            }

            return $"Hello {person.FirstName}{middle}{person.LastName}!";
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
    }

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "ConsolidatedHelloService";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
