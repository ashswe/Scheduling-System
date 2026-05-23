using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}
