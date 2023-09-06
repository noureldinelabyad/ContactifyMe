using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Models
{
    public  class PersonModel
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Zwischenname { get; set; }
        public string email { get; set; }
        public string Telefonnummer { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public int PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }

    }

   
}
