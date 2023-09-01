using PersonalContactInformation.Models;

namespace PersonalContactInformation.Views;


[QueryProperty(nameof(ContactId) , "Id")]   //navegate to the main page and id spacified in main page 
public partial class EditContact : ContentPage
{

	private Models.Contact contact;
	public EditContact()
	{
		InitializeComponent();
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepo.GetContactById(int.Parse(value));
			if (contact != null)
			{
				ContactCtrl.Name = contact.Name;
				ContactCtrl.Email = contact.Email;
				ContactCtrl.PhoneNumber = contact.PhoneNumber;
			}
		}
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
        contact.Name = ContactCtrl.Name;
		contact.Email = ContactCtrl.Email;
		contact.PhoneNumber = ContactCtrl.PhoneNumber;

		ContactRepo.UpdateContact(contact);

    }
}