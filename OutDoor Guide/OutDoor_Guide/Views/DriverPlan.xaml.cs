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
    public partial class DriverPlan : ContentPage
    {
        private List<Plans> MyPlans;
        private int resid;

        public DriverPlan()
        {
            InitializeComponent();
            string uname = "";
            //Get Loggedin user name
            if (Application.Current.Properties.ContainsKey("Login"))
            {
                uname = Application.Current.Properties["Login"] as string;
            }
            Title = "PLANS : " + uname;

           
            if (Application.Current.Properties.ContainsKey("RessourceID"))
            {
                resid = (int) Application.Current.Properties["RessourceID"];
            }

            getData();
        }

        //Get Driver Plan
        //return List of Plan
        private async void getData()
        {
            MyPlans = await App.Database.GetMyPlans(resid);
            PlanList.ItemsSource = MyPlans;
        }

        //
        private void PlanList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem != null)
                {
                    Plans p = e.SelectedItem as Plans;
                    Navigation.PushAsync(new MenuPlan(p.planid));
                    ((ListView)sender).SelectedItem = null;
                }
            }catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}