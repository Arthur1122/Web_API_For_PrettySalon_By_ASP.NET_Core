using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretty_Salon.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public int ClientPhoneNumber { get; set; }
    }
}

