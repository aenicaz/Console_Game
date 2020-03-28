using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace WcfService
{
    public class Host
    {
        public static void Main()
        {
            using (var host = new ServiceHost(typeof(Service1)))
            {
                host.Open();
                Console.WriteLine("Служба запущена");
                Console.ReadLine();
            }
        }
    }
}