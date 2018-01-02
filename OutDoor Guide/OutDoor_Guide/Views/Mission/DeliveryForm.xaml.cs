using OutDoor_Guide.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OutDoor_Guide.Views.Mission;

namespace OutDoor_Guide.Views.Mission
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryForm : ContentPage
    {
        List<DeliveryFormModel> mList;
        private int planID;

        public DeliveryForm()
        {
            InitializeComponent();
        }

        public DeliveryForm(int planID)
        {
            InitializeComponent();
            this.planID = planID;
            getData();
        }

        private async void getData()
        {
            mList = await App.Database.GetDeliveryFromByPlanID(planID);
            List.ItemsSource = mList;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try{
                if (e.SelectedItem != null)
                {
                    var res = e.SelectedItem as DeliveryFormModel;
                    Navigation.PushAsync(new FolderServicesPage(int.Parse(res.otid)));
                    ((ListView)sender).SelectedItem = null;
                }
            }catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}