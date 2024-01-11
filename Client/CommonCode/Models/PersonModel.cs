using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCode.Services;


namespace CommonCode.Models
{
    public class PersonModel
    {
        public bool IsSearchResult { get; set; }

        public int Id { get; set; }

        public string? Nachname { get; set; }

        public string? Vorname { get; set; }

        public string? Zwischenname { get; set; }

        public string? Email { get; set; }

        public string? Strasse { get; set; }

        public string? Hausnummer { get; set; }

        public string? PLZ { get; set; }
        [Required]

        public string? Stadt { get; set; }

        public string? Land { get; set; }

        public string? Gender { get; set; }

        public List<Telefonnummer> PersonNummern { get; set; } = new List<Telefonnummer>();

        public class Telefonnummer
        {
            public int Id { get; set; }
            public int PersonId { get; set; }
            public string? TelNummer { get; set; }
        }
    }
}
