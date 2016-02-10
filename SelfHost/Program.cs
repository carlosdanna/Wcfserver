using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8085/myFirstService");
            using (ServiceHost host = new ServiceHost(typeof(SelfHostedService), baseAddress)) 
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.ReadLine();
                host.Close();
            }
       
        }
    }
}
