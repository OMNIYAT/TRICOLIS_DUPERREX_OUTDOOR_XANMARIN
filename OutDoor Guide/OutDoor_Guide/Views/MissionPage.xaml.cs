using OutDoor_Guide.Model;
using OutDoor_Guide.Views.Mission;
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
    public partial class MissionPage : ContentPage
    {
        private int planID;
        private Plans Plan;
        public MissionPage()
        {
            InitializeComponent();
        }

        public MissionPage(int planID)
        {
            InitializeComponent();
            this.planID = planID;

            Plan_ID.Text = this.planID + "";

            getData();
        }

        private async void getData()
        {
            List<Plans> plans = await App.Database.GetPlanById(planID);
            if (plans != null && plans.Count > 0)
            {
                Plan = plans[0];
                Date.Date = Plan.plandate;
                Aides.Text = Plan.aides;
                Instruction.Text = Plan.planinstruction;
            }

        }

        private void Depart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeliveryForm(planID));
        }

        private void Chargement_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoadingFormPage(planID));
        }
    }
}