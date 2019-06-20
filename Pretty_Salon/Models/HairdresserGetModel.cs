using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Models
{
    public class HairdresserModel
    {
        public int HairdresserId { get; set; }
        public string HairdresserName { get; set; }
        public SalonModel Salon { get; set; }
    }
}
