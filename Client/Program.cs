using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HelloService.HelloClient();

            var result = client.Hello(new HelloService.Person { FirstName = "John", LastName = "Vernon" });

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
