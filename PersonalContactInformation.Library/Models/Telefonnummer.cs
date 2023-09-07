using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    internal class Telefonnummer
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Nummer { get; set; }
    }
}
