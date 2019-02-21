using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloService
{
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
}
