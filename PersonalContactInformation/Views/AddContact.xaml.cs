using PersonalContactInformation.Models;
using System.Diagnostics;

namespace PersonalContactInformation.Views;

public partial class AddContact : ContentPage
{
	public AddContact()
	{
		InitializeComponent();
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
		var newContact = new Models.Contact()
		{
			Nachname = ContactCtrl.Name,
			Email = ContactCtrl.Email,
			Telefonnummer = ContactCtrl.PhoneNumber,
            Hausnummer = ContactCtrl.Hausnummer,
            Straﬂe = ContactCtrl.Straﬂe,

        };
		
		ContactRepo.AddContact(newContact);

    }
}