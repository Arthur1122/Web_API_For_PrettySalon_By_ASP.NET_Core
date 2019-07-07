using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data.Entities
{
    public class Salon
    {
        public int SalonId { get; set; }
        public string  Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
