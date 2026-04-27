using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02.Models
{
    internal class Registration
    {
        public int id { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }
        public string Note { get; set; }
        public string RegistrationDateTime { get; set; }
    }
}
