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
    public partial class MenuPlan : ContentPage
    {
        private int planID;

        public MenuPlan()
        {

        }

        public MenuPlan(int planID)
        {
            InitializeComponent();
            this.planID = planID;
        }

        private void Mission_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MissionPage(planID));
        }

        private void Frais_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FraisPage(planID));
        }

        private void Information_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InformationPage(planID));
        }
    }
}