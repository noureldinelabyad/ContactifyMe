using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Models
{
    public  class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nachname is required.")]
        public string Nachname { get; set; }

        [Required]
        public string Vorname { get; set; }
        [Required]

        public string Zwischenname { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Telefonnummer { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Strasse { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Hausnummer { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public int PLZ { get; set; }
        [Required]

        public string Stadt { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Land { get; set; }
        [Required(ErrorMessage = "Nachname is required.")]

        public string Gender { get; set; }


    }

   
}
