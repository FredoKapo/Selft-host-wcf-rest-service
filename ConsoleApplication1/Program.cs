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
  
   

    sealed class Program : ITVRemoteProxy
    {

        static void Main(string[] args)
        {

            Uri baseAddress = new Uri("http://localhost:8090");

            StartServiceHost(baseAddress);
        }

        private static void StartServiceHost(Uri baseAddress)
        {

            ServiceHost host = new ServiceHost(typeof(Program), baseAddress);
            WebHttpBinding binding = new WebHttpBinding();

            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITVRemoteProxy), binding, "ServiceHost");
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
            httpBehavior.DefaultOutgoingRequestFormat = WebMessageFormat.Json;
            httpBehavior.DefaultBodyStyle = WebMessageBodyStyle.Bare;
            binding.CrossDomainScriptAccessEnabled = true;
            endpoint.Behaviors.Add(httpBehavior);

            host.Open();

            Console.WriteLine(@"go to http://localhost:8090/ServiceHost/GetHostInfos to test");
            Console.ReadLine();

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
            
            return info;
        }

    }


}
