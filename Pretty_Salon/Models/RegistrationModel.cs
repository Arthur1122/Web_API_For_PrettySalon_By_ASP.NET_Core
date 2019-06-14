using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Models
{
    public class RegistrationModel
    {
        public string TimeOfDay { get; set; }
        public DateTime Day { get; set; } 
        public string ClientName { get; set; }
        public string SalonName { get; set; }
        public string HairdresserName { get; set; }

    }
}
