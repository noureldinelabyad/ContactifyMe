using System.Security.Cryptography.X509Certificates;

namespace PersonalContactInformation.Views.Controls;

public partial class ContactControl : ContentView
{
	

	public event EventHandler<EventArgs> OnSave;



	public ContactControl()
	{
		InitializeComponent();
	}
    public string Name
    {
        get { return Entry_Name.Text; }
        set { Entry_Name.Text = value; }

    }

    public string Email
    {
        get { return Entry_Email.Text; }
        set { Entry_Email.Text = value; }

    }

    public int PhoneNumber
    {
        get { return int.Parse(Entry_PhoneNumber.Text); }
        set { Entry_PhoneNumber.Text = value.ToString(); }

    }


    private void BtnContactSave_Clicked(object sender, EventArgs e) //submit on this click 
	{
        OnSave?.Invoke(sender, e);
		
	}


}