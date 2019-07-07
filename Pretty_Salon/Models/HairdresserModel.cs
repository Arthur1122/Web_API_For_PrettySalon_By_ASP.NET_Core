using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Models
{
    public class HairdresserModel
    {
        public int HairdresserId { get; set; }
        public string HairdresserFirstName { get; set; }
        public string HairdresserLastName { get; set; }
        public int HairdresserPhoneNumber { get; set; }
        public string HairdresserCategory { get; set; }
        public SalonModel Salon { get; set; }
    }
}
