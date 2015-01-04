using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Web;

namespace WcfService1
{
    

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TVRemoteProxy : ITVRemoteProxy
    {
        public HostInfo GetHostInfos()
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
           
            return new HostInfo()
            {
                MachineName = "oops",
                Processes = new List<ProcessInfo>(){
                new ProcessInfo(){ ProcessIsActive = true, ProcessName="process1",ProcessDescription=""}
            }
            };
        }
    }

}