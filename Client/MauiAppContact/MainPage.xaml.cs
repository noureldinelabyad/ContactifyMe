//using MauiContact.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace MauiAppContact
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            //InitializeComponent();
        }


        private void BtnAddContact_Clicked(object sender, EventArgs e)
        {
            //Shell.Current.GoToAsync(nameof(AddContact));
        }



        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //  var results = new ObservableCollection<Models.Contact>(ContactRepo.Searchcontacts(((SearchBar)sender).Text));
            //  xmalContactList.ItemsSource = results;

        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {

            //    string searchText = searchBar.Text;

            //    if (!string.IsNullOrEmpty(searchText))
            //    {
            //        var results = new ObservableCollection<Models.Contact>(ContactRepo.Searchcontacts(searchText));

            //        if (results.Count > 0)
            //        {
            //            xmalContactList.ItemsSource = results;
            //        }
            //        else
            //        {
            //            bool addContact = await DisplayAlert("Contact Not Found", $"Contact with name '{searchText}' does not exist. Do you want to add it?", "Yes", "No");

            //            if (addContact)
            //            {
            //                // Navigate to the AddContact page
            //                await Shell.Current.GoToAsync(nameof(AddContact));
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // If the search text is empty, reload all contacts
            //        LoadContacts();
            //    }
        }

    }
}