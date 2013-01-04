using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BusinessLogic.Models
{
    [DataContract]
    public class DonViModelDrop
    {
        [DataMember]
        public string MaDonVi { get; set; }

        [DataMember]
        public string TenDonVi { get; set; }
    }
}