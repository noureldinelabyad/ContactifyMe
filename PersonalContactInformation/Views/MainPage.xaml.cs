using PersonalContactInformation.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace PersonalContactInformation.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		//LoadContacts();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		LoadContacts();
    }

    private void LoadContacts()
	{
		var result = new ObservableCollection <Models.Contact>(ContactRepo.GatAllContacts());
		xmalContactList.ItemsSource = result;
	}

    private async void xmalContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (xmalContactList.SelectedItem != null)
			await Shell.Current.GoToAsync($"{nameof(EditContact)}?Id={((Models.Contact)xmalContactList.SelectedItem).Id}");
    }

    private void xmalContactList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		xmalContactList.SelectedItem = null;
    }

    private void BtnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContact));
    }

    private void MenueItemDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;
        ContactRepo.DeletContact(contact.Id);
        LoadContacts();

    }

    private void MenuItemEdit_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Models.Contact;
        Shell.Current.GoToAsync($"{nameof(EditContact)}?Id={contact.Id}");  


    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var results = new ObservableCollection<Models.Contact>(ContactRepo.Searchcontacts(((SearchBar)sender).Text));
        xmalContactList.ItemsSource = results;

    }
}