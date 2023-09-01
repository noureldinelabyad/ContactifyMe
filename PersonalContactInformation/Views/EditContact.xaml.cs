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
				ContactCtrl.Name = contact.Nachname;
				ContactCtrl.Email = contact.Email;
				ContactCtrl.PhoneNumber = contact.Telefonnummer;
				ContactCtrl.Straﬂe = contact.Straﬂe;
				ContactCtrl.Land = contact.Land;
				ContactCtrl.Stadt = contact.Stadt;
				ContactCtrl.Vorname = contact.Vorname;
                ContactCtrl.Zwischenname = contact.Zwischenname;
                ContactCtrl.PLZ = contact.PLZ;
                ContactCtrl.Hausnummer = contact.Hausnummer;



            }
        }
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
        contact.Nachname = ContactCtrl.Name;
		contact.Email = ContactCtrl.Email;
		contact.Hausnummer = ContactCtrl.Hausnummer;
		contact.Straﬂe = ContactCtrl.Straﬂe;
		contact.PLZ = ContactCtrl.PLZ;
		contact.Land = ContactCtrl.Land;
		contact.Stadt = ContactCtrl.Stadt;
		contact.Vorname = ContactCtrl.Vorname;
        contact.Zwischenname = ContactCtrl.Zwischenname;




        ContactRepo.UpdateContact(contact);

    }
}