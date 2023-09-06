

using Microsoft.Maui.ApplicationModel.Communication;
using PersonalContactInformation.Views;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PersonalContactInformation.Models  //  repo way of orgnazing the code  putting all the methodes in a seprate class (static repo: creat once and stuck in the memory)
{
    public class ContactRepo
    {
        // DATA List
        public static List<Contact> ContactList = new List<Contact>()
        {

            new Contact() {Id = 1, Nachname="John Doe", Email="Doe@doe.com", Telefonnummer = 123456789 ,Zwischenname="ol" , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact(){Id =2, Nachname ="Frank Hook", Email = "Frank@frank.com", Telefonnummer = 012345787 , Zwischenname="ol" , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 3, Nachname = "Frederick Asante", Email="Asante@gmail.com", Telefonnummer=024587795 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 4, Nachname="James Moore ", Email="James@doe.com", Telefonnummer = 78965 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact(){Id =5, Nachname ="Andrews Hughes", Email = "Andrews@frank.com", Telefonnummer = 145563 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 6, Nachname = "Rick Mars", Email="Rick@gmail.com", Telefonnummer=7896665 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 7, Nachname="Mabel Rosemond", Email="Mabel@doe.com", Telefonnummer = 741258 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact(){Id =8, Nachname ="Gifty Kicks", Email = "Gifty@frank.com", Telefonnummer = 9632587 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 9, Nachname = "Frankline Davis", Email="Frankline@gmail.com", Telefonnummer=1230457 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 10, Nachname="Genesis Great", Email="Genesis@doe.com", Telefonnummer = 012455785 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact(){Id =11, Nachname ="Simon Peter", Email = "Simon@frank.com", Telefonnummer = 032657895 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"},
            new Contact() {Id = 12, Nachname = "Seth Klean", Email="Seth@gmail.com", Telefonnummer=045789963 , Vorname="test" , Straße="Axel Springer" , Hausnummer=552244 , Land= "Germany" , PLZ= 22454 , Stadt="Hamburg"}


        };

        //creat method 

        public static async void AddContact(Contact contact)
        {
            if (contact != null)
            {
                var checkEmail = ContactList.FirstOrDefault(x => x.Email.Equals(contact.Email)); //not 2 have same email

                if (checkEmail != null) //email found 
                {

                    await Shell.Current.DisplayAlert("Error", "Contact already added", "Ok");
                    return;
                }

                int maxId = ContactList.Max(x => x.Id);
                contact.Id = maxId + 1;
                ContactList.Add(contact);
                await Shell.Current.DisplayAlert("Succes", "Contact Added Done ", "Ok");
                //Shell.Current.GoToAsync("..");// pass to the homepage navegating after adding 
                // await Shell.Current.GoToAsync($"//{ nameof(MainPage)}"); // pass to the homepage navegating after adding - an other method 
                await Shell.Current.GoToAsync("//MainPage");



            }
        }

        //Get Method
        //read 1 (all) method 
        public static List<Contact> GatAllContacts() => ContactList;


        //Read 2 Method  (indivedial)
        public static Contact GetContactById(int id)
        {
            var result = ContactList.FirstOrDefault(x => x.Id == id);
            return result;

        }

        //Update Method 
        public static async void UpdateContact(Contact contact)
        {


            var result = ContactList.FirstOrDefault(x => x.Id == contact.Id); //id set auto so no need to update 
            if (result != null)
            {
                result.Nachname = contact.Nachname;
                result.Email = contact.Email;
                result.Telefonnummer = contact.Telefonnummer;
                result.Hausnummer = contact.Hausnummer;
                result.Straße = contact.Straße;
                 result.PLZ = contact.PLZ;
                result.Land  = contact.Land;
                 result.Stadt = contact.Stadt;
                result.Vorname = contact.Vorname;
                 result.Zwischenname = contact.Zwischenname;

                await Shell.Current.DisplayAlert("Succes", "Contact Updated ", "Ok");

                //Shell.Current.GoToAsync(".."); // pass to the homepage navegating after updating 
                // Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                // await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                await Shell.Current.GoToAsync("//MainPage");

            }
        }


        //Delete Method 
        public static async void DeletContact(int Id)
        {
            var result = ContactList.FirstOrDefault(x => x.Id == Id);
            if (result != null)
            {
                ContactList.Remove(result);

                await Shell.Current.DisplayAlert("Succes", "Contact Deleted ", "Ok");
                //Shell.Current.GoToAsync("..");// pass to the homepage navegating after updating 
                // Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                await Shell.Current.GoToAsync("//MainPage");

            }
        }

        //search method 
        public static List<Contact> Searchcontacts(string filter)
        {
            var contacts = ContactList.Where(x => !string.IsNullOrWhiteSpace(x.Nachname) && x.Nachname.ToLower().Contains(filter.ToLower())).ToList();

            if (contacts == null || contacts.Count <= 0)
                contacts = ContactList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(filter.ToLower())).ToList();

            //else return contacts;

            //if (contacts == null || contacts.Count <= 0)
             //contacts = ContactList.Where(x => x.Telefonnummer == int .Parse (filter)).ToList();

            else return contacts;
            return contacts;
        }


    }
}
