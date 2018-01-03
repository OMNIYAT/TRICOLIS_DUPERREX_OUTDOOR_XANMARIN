using OutDoor_Guide.Model;
using OutDoor_Guide.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutDoor_Guide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /*
        Login Button event
        Check given username and password match with database.
        On successful login redirect to Update Page 
        */
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                SyncSoapClient serviceClient = new SyncSoapClient();
                serviceClient.helloCompleted += ServiceClient_helloCompleted;
                serviceClient.helloAsync();

                /*
                string uname = username.Text;
                string pwd = password.Text;

                if (uname == null || uname.Trim() == "")
                {
                    await DisplayAlert("Error", "Enter username", "OK");
                }
                else if (pwd == null || pwd.Trim() == "")
                {
                    await DisplayAlert("Error", "Enter password", "OK");
                }
                else
                {
                    List<User> loggedInUser = await App.Database.GetUser(uname, pwd);
                    if (loggedInUser != null && loggedInUser.Count == 1)
                    {
                        Application.Current.Properties["UserID"] = loggedInUser[0].userid;
                        Application.Current.Properties["Login"] = loggedInUser[0].login;
                        Application.Current.Properties["RessourceID"] = loggedInUser[0].ressourceid;

                        await Navigation.PopAsync();
                        await Navigation.PushAsync(new DriverPlan());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid username or password", "OK");
                    }
                }*/
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }


        }

        private async void ServiceClient_helloCompleted(object sender, helloCompletedEventArgs e)
        {
            try
            {
                await DisplayAlert("Service Call", "HI", "OK");
            }
            catch (Exception ex) { }
        }
    }
}