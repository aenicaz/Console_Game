using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Engine
{
    [DataContract]
    public class AllPlayers
    {
        [DataMember]
        public static List<PlayerServer> players = new List<PlayerServer>();
    }
}