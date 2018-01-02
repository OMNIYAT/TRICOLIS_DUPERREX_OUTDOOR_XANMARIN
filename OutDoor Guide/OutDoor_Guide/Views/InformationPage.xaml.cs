using OutDoor_Guide.Helpers;
using OutDoor_Guide.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace OutDoor_Guide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {
        private List<PickerModel> hourList;
        private List<PickerModel> minuteList;
        private int planID;

        List<Trc_Plan_Caracteristiques> infos;
        List<int> DelIds;

        public InformationPage()
        {
            InitializeComponent();
        }

        public InformationPage(int planID)
        {
            InitializeComponent();
            setupLists();
            infos = new List<Trc_Plan_Caracteristiques>();
            DelIds = new List<int>();
            this.planID = planID;
            updateList();
            add.Clicked += Add_Clicked;
            delete.Clicked += Delete_Clicked;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (DelIds == null || DelIds.Count == 0)
            {
                await DisplayAlert("Oops", "Select atleat one checkbox", "Ok");
            }
            else
            {
                var action = await DisplayActionSheet("Are you sure?", "Cancel", null, "Yes", "No");
                if (action.Equals("Yes"))
                {
                    await App.Database.DeleteInfos(DelIds);
                    this.DelIds = new List<int>();
                    updateList();
                }
            }
        }

        private bool validate()
        {
            if(hour_start.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select Start Hour", "Ok");
                return false;
            }

            if(minute_start.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select Start minute", "Ok");
                return false;
            }

            if (hour_end.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select End Hour", "Ok");
                return false;
            }

            if (minute_end.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select End minute", "Ok");
                return false;
            }

            if (km_start.Text == null || km_start.Text.ToString().Equals(""))
            {
                DisplayAlert("Opps", "Enter KM Start", "Ok");
                return false;
            }

            if (pression_start.Text == null || pression_start.Text.ToString().Equals(""))
            {
                DisplayAlert("Opps", "Enter Pression Start", "Ok");
                return false;
            }

            if (km_end.Text == null || km_end.Text.ToString().Equals(""))
            {
                DisplayAlert("Opps", "Enter KM End", "Ok");
                return false;
            }

            if (pression_end.Text == null || pression_end.Text.ToString().Equals(""))
            {
                DisplayAlert("Opps", "Enter Pression End", "Ok");
                return false;
            }

            return true;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            
            Trc_Plan_Caracteristiques info = new Trc_Plan_Caracteristiques();

            info.heurearrive = (hour_start.SelectedItem as PickerModel).text + ":" + (minute_start.SelectedItem as PickerModel).text;
            info.heuredepart = (hour_end.SelectedItem as PickerModel).text + ":" + (minute_end.SelectedItem as PickerModel).text;

            info.kmarrive = double.Parse(km_start.Text.ToString());
            info.kmdepart = double.Parse(km_end.Text.ToString());

            info.pressionpneuavant = pression_start.Text.ToString();
            info.pressionpneuapres = pression_end.Text.ToString();

            info.planid = this.planID;

            await App.Database.SaveInfo(info);
            updateList();

        }

        private async void updateList()
        {
            infos = await App.Database.GetInfosByPID(planID);
            list.ItemsSource = infos;
        }

        private void setupLists()
        {
            hourList = new List<PickerModel>();
            minuteList = new List<PickerModel>();
            for(int i=0; i<24; i++)
            {
                string str = i + "";
                if (i < 10)
                {
                    str = "0" + i;
                }
                hourList.Add(new PickerModel { id = i, text = str });
            }

            for (int i = 0; i < 61; i++)
            {
                string str = i + "";
                if (i < 10)
                {
                    str = "0" + i;
                }
                minuteList.Add(new PickerModel { id = i, text = str });
            }

            hour_start.ItemsSource = hourList;
            hour_start.ItemDisplayBinding = new Binding("text");
            minute_start.ItemsSource = minuteList;
            minute_start.ItemDisplayBinding = new Binding("text");

            hour_end.ItemsSource = hourList;
            hour_end.ItemDisplayBinding = new Binding("text");
            minute_end.ItemsSource = minuteList;
            minute_end.ItemDisplayBinding = new Binding("text");

        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            try
            {
                CheckBox chk = sender as CheckBox;
                DelIds.Add(int.Parse(chk.Text));
            }
            catch (Exception ex)
            {

            }
        }
    }
}