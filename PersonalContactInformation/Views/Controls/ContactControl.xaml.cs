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

     public string Vorname
    {
        get { return Entry_Vorname.Text; }
        set { Entry_Vorname.Text = value; }

    }

    public string Zwischenname
    {
        get { return Entry_Zwischenname.Text; }
        set { Entry_Zwischenname.Text = value; }

    }


     public string Straﬂe
    {
        get { return Entry_Straﬂe.Text; }
        set { Entry_Straﬂe.Text = value; }

    }

    public int Hausnummer
    {
        get { return int.Parse(Entry_Hausnummer.Text); }
        set { Entry_Hausnummer.Text = value.ToString(); }

    }

     public int PLZ
    {
        get { return int.Parse(Entry_PLZ.Text); }
        set { Entry_PLZ.Text = value.ToString(); }

     }


    public string Stadt
    {
        get { return Entry_Stadt.Text; }
        set { Entry_Stadt.Text = value; }

    }

     public string Land
    {
        get { return Entry_Land.Text; }
        set { Entry_Land.Text = value; }

    }



    private void BtnContactSave_Clicked(object sender, EventArgs e) //submit on this click 
	{
        if (nameValidator.IsNotValid)   
        {
            Shell.Current.DisplayAlert("Error", "Name is required", "Ok");

            return;
        }

        if(emailValidator.IsNotValid)
        {
            foreach(var error in emailValidator.Errors)
            {
                Shell.Current.DisplayAlert("Error", error.ToString(), "Ok");
            }

            return;
        }

        OnSave?.Invoke(sender, e);

		
	}


}