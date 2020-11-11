using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanfossTestApplication.Models
{
    public class EquipmentForm
    {
        public string vendorcode { get; set; }      
        public string description { get; set; }       
        public double cost { get; set; }        
        public bool onwarehouse { get; set; }
    }
}
