

using Microsoft.Maui.ApplicationModel.Communication;
using PersonalContactInformation.Views;
using System.Security.Cryptography.X509Certificates;

namespace PersonalContactInformation.Models  //  repo way of orgnazing the code  putting all the methodes in a seprate class (static repo: creat once and stuck in the memory)
{
    public  class ContactRepo
    {
        // DATA List
        public static List<Contact> ContactList = new List<Contact>() 
        {

             new Contact() {Id = 1, Name="John Doe", Email="Doe@doe.com", PhoneNumber = 123456789},
            new Contact(){Id =2, Name ="Frank Hook", Email = "Frank@frank.com", PhoneNumber = 012345787},
            new Contact() {Id = 3, Name = "Frederick Asante", Email="Asante@gmail.com", PhoneNumber=024587795},
            new Contact() {Id = 4, Name="James Moore ", Email="James@doe.com", PhoneNumber = 78965},
            new Contact(){Id =5, Name ="Andrews Hughes", Email = "Andrews@frank.com", PhoneNumber = 145563},
            new Contact() {Id = 6, Name = "Rick Mars", Email="Rick@gmail.com", PhoneNumber=7896665},
            new Contact() {Id = 7, Name="Mabel Rosemond", Email="Mabel@doe.com", PhoneNumber = 741258},
            new Contact(){Id =8, Name ="Gifty Kicks", Email = "Gifty@frank.com", PhoneNumber = 9632587},
            new Contact() {Id = 9, Name = "Frankline Davis", Email="Frankline@gmail.com", PhoneNumber=1230457},
            new Contact() {Id = 10, Name="Genesis Great", Email="Genesis@doe.com", PhoneNumber = 012455785},
            new Contact(){Id =11, Name ="Simon Peter", Email = "Simon@frank.com", PhoneNumber = 032657895},
            new Contact() {Id = 12, Name = "Seth Klean", Email="Seth@gmail.com", PhoneNumber=045789963}


        };

        //creat method 

        public static async void AddContact (Contact contact)
        {
            if (contact != null)
            {
                var checkEmail = ContactList.FirstOrDefault(x=>x.Email.Equals( contact.Email)); //not 2 have same email

                if(checkEmail != null) //email found 
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
        public static Contact GetContactById (int id)
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
                result . Name = contact.Name;
                result . Email = contact.Email;
                result . PhoneNumber = contact.PhoneNumber;
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
            var contacts = ContactList.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.ToLower().Contains(filter.ToLower())).ToList();
            
            if (contacts == null || contacts.Count <= 0)
                contacts = ContactList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(filter.ToLower())).ToList();

            //else return contacts;

            //if (contacts == null || contacts.Count <= 0)
               // contacts = ContactList.Where(x => x.PhoneNumber == int .Parse (filter)).ToList();

            else return contacts;
            return contacts;
        }


    }
}
