using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Zwischenname { get; set; }
        public int Telefonnummer { get; set; }
        public string EMail { get; set; }
        public string Straße { get; set; }
        public int Hausnummer { get; set; }
        public int PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set;}
    }
}
