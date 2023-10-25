using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    /// <summary>
    /// Stores the Phonenumbers of People with a pointer back at a person
    /// </summary>
    public class Telefonnummer
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string TelNummer { get; set; }
    }
}
