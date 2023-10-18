using MauiContact.Services;
using MauiContact.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;




namespace MauiContact
{
    public partial class MainPage : ContentPage
    {

        private string _baseUrl = "https://localhost:7078"; // URL of the API database

        public MainPage()
        {
            InitializeComponent();
            GetAllPersonsList();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            List<PersonModel> persons = await GetAllPersonsList();
            xmalContactList.ItemsSource = persons;
        }

        List<PersonModel> _PersonList;



        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllPersonsList();
        }

        //public static List<PersonModel> GetAllPersonsList() => _PersonList ;

        public async Task<List<PersonModel>> GetAllPersonsList()
        {
            var returnResponse = new List<PersonModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Persons";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<List<PersonModel>>(response);


                    }

                    foreach (var person in returnResponse)

                    {



                        if (person.Zwischenname == null)
                        {

                            person.Zwischenname = " ";

                        }



                        if (person.Gender == null)
                        {

                            person.Gender = " ";

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                //Log or handle the exception gracefully.
                string Msg = ex.Message;
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            return returnResponse;
        }



        private void BtnSearch_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnAddContact_Clicked(object sender, EventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            string searchText = e.NewTextValue;

            if (!string.IsNullOrEmpty(searchText))
            {
                var results = allPersons
                    .Where(person => person.Nachname.Contains(searchText) || person.Vorname.Contains(searchText))
                    .ToList();

                xmalContactList.ItemsSource = new ObservableCollection<PersonModel>(results);
            }
            else
            {
                xmalContactList.ItemsSource = new ObservableCollection<PersonModel>(allPersons);
            }

        }

        private void xmalContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void xmalContactList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void MenueItemDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}