using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerWCF
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            var host = new ServiceHost(typeof(ProcessManager));
                host.AddServiceEndpoint(typeof(IContractProcess), new BasicHttpBinding(),
                                        new Uri(@"http://127.0.0.1:60001/IContractProcess"));
                host.Open();
                Console.ReadLine();
        }
    }
}
