using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfService1
{
    [DataContract]
    public class HostInfo
    {
        [DataMember]
        public String MachineName { get; set; }

        [DataMember]
        public List<ProcessInfo> Processes { get; set; }
        
    }


    [DataContract]
    public class ProcessInfo
    {
        [DataMember]
        public String ProcessName { get; set; }

        [DataMember]
        public bool ProcessIsActive { get; set; }
        [DataMember]
        public String ProcessDescription { get; set; }
    }
}
