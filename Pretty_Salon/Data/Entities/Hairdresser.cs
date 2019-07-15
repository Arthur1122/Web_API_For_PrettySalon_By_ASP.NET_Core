using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data.Entities
{
    public class Hairdresser
    {
        public int HairdresserId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public Salon Salon { get; set; }
    }
}
