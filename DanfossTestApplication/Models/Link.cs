using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DanfossTestApplication.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
