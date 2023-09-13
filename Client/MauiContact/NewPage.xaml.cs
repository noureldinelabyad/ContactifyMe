using MauiContact.Repo;
using MauiContact.Models;
using MauiContact.Services;

namespace MauiContact;

public partial class NewPage : ContentPage
{
    readonly IPersonRepo personServer = new PersonServiceRepo();
	public NewPage()
	{
		InitializeComponent();
	}




    //PersonModel Person = await PersonServer .GetPerson();
    //if (person == null)
    //    {
          
    //    }















    private void BtnSearch_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnAddContact_Clicked(object sender, EventArgs e)
    {

    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

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

    private void MenuItemEdit_Clicked(object sender, EventArgs e)
    {

    }
}