using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCode.Services;

namespace CommonCode.Models
{
    public class AddUpdatePersonRequest
    {
        public int Id { get; set; }
        public string? Nachname { get; set; }
        public string? Vorname { get; set; }
        public string? Zwischenname { get; set; }
        public string? Email { get; set; }
        public List<PersonModel.Telefonnummer> ?PersonNummern { get; set; } // Assuming this is correct
        public string? Strasse { get; set; }
        public string? Hausnummer { get; set; }
        public string? PLZ { get; set; }
        public string? Stadt { get; set; }
        public string? Land { get; set; }
        public string? Gender { get; set; }
    }
}
