using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data.Entities
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public DateTime Day { get; set; } = DateTime.MinValue;
        public string TimeOfDay { get; set; } 
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public int HairdresserId { get; set; }
        public Salon Salon { get; set; }
        public int SalonId { get; set; }
    }
}
