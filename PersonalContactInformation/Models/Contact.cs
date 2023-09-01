

namespace PersonalContactInformation.Models
{
     public class Contact
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Zwischenname { get; set; }
        public string Email { get; set; }
        public int Telefonnummer { get; set; }
        public string Straße { get; set; }
        public int Hausnummer { get; set; }
        public int PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }
    }
}
