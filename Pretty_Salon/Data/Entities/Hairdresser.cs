using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Data.Entities
{
    public class Hairdresser
    {
        public int HairdresserId { get; set; }
        public string Name { get; set; }
        public Salon Salon { get; set; }
    }
}
