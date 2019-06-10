using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data.Entities
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public DateTime DayAndTime { get; set; } = DateTime.MinValue;
        public Client Client { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public Salon Salon { get; set; }
    }
}
