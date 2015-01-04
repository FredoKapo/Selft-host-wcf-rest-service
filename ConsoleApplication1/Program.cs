using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Text;
using WcfService1; 

namespace ConsoleApplication1
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Uri baseAddress = new Uri("http://localhost:8090/MonitorService");

    //        // Create the ServiceHost.
    //        WebServiceHost host = new WebServiceHost(typeof(TVRemoteProxy),  baseAddress);
    //        ServiceEndpoint ep = host.AddServiceEndpoint(typeof(ITVRemoteProxy), new WebHttpBinding(), baseAddress);
    //        ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
    //        stp.HttpHelpPageEnabled = false;
    //        host.Open();
    //        Console.WriteLine("Service is up and running");
    //        Console.WriteLine("Press enter to quit ");
    //        Console.ReadLine();
    //        host.Close();


            
    //        //using (ServiceHost host = new ServiceHost(typeof(TVRemoteProxy)))//, baseAddress))
    //        //{
    //            //// Enable metadata publishing.:
    //            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    //            //smb.HttpGetEnabled = true;

    //            //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    //            //host.Description.Behaviors.Add(smb);

    //            ////// Open the ServiceHost to start listening for messages. Since
    //            ////// no endpoints are explicitly configured, the runtime will create
    //            ////// one endpoint per base address for each service contract implemented
    //            ////// by the service.
    //            //host.Open();

    //            //Console.WriteLine("The service is ready at {0}", baseAddress);
    //            //Console.WriteLine("Press <Enter> to stop the service.");
    //            //Console.ReadLine();

    //            //// Close the ServiceHost.
    //            //host.Close()
    //    //    }
    //    }
    //}


    sealed class Program : ITVRemoteProxy 
    {

        static void Main(string[] args)
        {

            Uri baseAddress = new Uri("http://localhost:8090");

            HostWithServiceHost(baseAddress);

            HostWithWebServiceHost(baseAddress);
        }

        private static void HostWithServiceHost(Uri baseAddress)
        {

            ServiceHost host = new ServiceHost(typeof(Program), baseAddress);
            WebHttpBinding binding = new WebHttpBinding();

            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITVRemoteProxy), binding, "ServiceHost");
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
                httpBehavior.DefaultOutgoingRequestFormat = WebMessageFormat.Json ;
                httpBehavior.DefaultBodyStyle = WebMessageBodyStyle.Bare;
                binding.CrossDomainScriptAccessEnabled = true;
            endpoint.Behaviors.Add(httpBehavior);

            host.Open();

            Console.WriteLine(@"go to http://localhost:8090/ServiceHost/SomeOperation to test");
            Console.ReadLine();

        }

        private static void HostWithWebServiceHost(Uri baseAddress)
        {

            WebServiceHost host = new WebServiceHost(typeof(Program), baseAddress);
            WebHttpBinding binding = new WebHttpBinding();
            host.AddServiceEndpoint(typeof(ITVRemoteProxy), binding, "WebServiceHost");
            host.Open();
            binding.CrossDomainScriptAccessEnabled = true;
            Console.WriteLine(@"go to http://localhost:8090/WebServiceHost/SomeOperation to test");
            Console.ReadLine();
            host.Close();

        }

        public HostInfo GetHostInfos()
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            var info = new HostInfo()
            {
                MachineName = "oops",
                Processes = new List<ProcessInfo>(){
                    new ProcessInfo(){ ProcessIsActive = true, ProcessName="process1",ProcessDescription=""}
                ,new ProcessInfo(){ ProcessIsActive = true, ProcessName="process2",ProcessDescription=""}
                }
            };
            Console.WriteLine(info.Processes[0].ProcessName);
            return info;
        }

    }


}
