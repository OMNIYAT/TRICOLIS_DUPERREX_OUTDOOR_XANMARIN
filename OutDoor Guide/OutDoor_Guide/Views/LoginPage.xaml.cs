using OutDoor_Guide.Model;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
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
                        Application.Current.Properties["UserID"] = loggedInUser[0].UserID;
                        Application.Current.Properties["Login"] = loggedInUser[0].Login;
                        Application.Current.Properties["RessourceID"] = loggedInUser[0].RessourceID;

                        await Navigation.PopAsync();
                        await Navigation.PushAsync(new UpdatePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid username or password", "OK");
                    }
                }
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}