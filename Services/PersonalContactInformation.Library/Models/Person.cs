using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    public class Person
    {
        /// <summary>
        /// Stores contact information of a person, phone numbers are stored in a seperate table
        /// </summary>
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string? Zwischenname { get; set; }
        public List<Telefonnummer> PersonNummern { get; set; }
        public string EMail { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set;}
        public string Gender { get; set; }
    }
}
