using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Models
{
    public class RegistrationModel
    {
        public int RegistrrationId { set; get; }
        public DateTime Day { get; set; } = DateTime.MinValue;
        public string TimeOfDay { get; set; }
        public int ClientId { get; set; }
        public int SalonId { get; set; }
        public int HairdresserId { get; set; }
    }
}
