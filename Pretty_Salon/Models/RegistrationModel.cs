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
        public ClientModel Client { get; set; }
        public SalonModel Salon { get; set; }
        public HairdresserModel Hairdresser { get; set; }
    }
}
