using OutDoor_Guide.Helpers;
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
    public partial class InformationPage : ContentPage
    {
        private List<PickerModel> hourList;
        private List<PickerModel> minuteList;
        private int planID;
        
        public InformationPage(int planID)
        {
            InitializeComponent();
            setupLists();
            this.planID = planID;
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
    }
}