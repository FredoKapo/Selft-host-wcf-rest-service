using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Web;

namespace WcfService1
{
    [ServiceContract]
    public interface ITVRemoteProxy
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetHostInfos", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped )]
       
        HostInfo GetHostInfos();
    }
}