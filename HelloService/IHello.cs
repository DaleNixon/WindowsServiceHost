using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloService
{
    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        string Hello(Person person);
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
}
