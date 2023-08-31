using PersonalContactInformation.Models;

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
			Name = ContactCtrl.Name,
			Email = ContactCtrl.Email,
			PhoneNumber = ContactCtrl.PhoneNumber
		};
		
		ContactRepo.AddContact(newContact);

    }
}