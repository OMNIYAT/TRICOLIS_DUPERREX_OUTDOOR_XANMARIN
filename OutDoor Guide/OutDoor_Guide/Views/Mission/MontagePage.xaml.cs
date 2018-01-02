using OutDoor_Guide.Model.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OutDoor_Guide.Views.Mission
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MontagePage : ContentPage
    {
        private double did;
        List<MontageResult> mList;
        private bool isTimerRunning = false;
        private int TimerSec = 900;
        public MontagePage()
        {
            InitializeComponent();
        }

        public MontagePage(double did)
        {
            this.did = did;
            InitializeComponent();
            getData();
            ignore.Clicked += Ignore_Clicked;
            back.Clicked += Back_Clicked;
            start.Clicked += Start_Clicked;
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            //Start Timer for 15 mins
            if (isTimerRunning)
                return;
            TimerSec = 900;
            isTimerRunning = true;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TimerSec--;
                int min = TimerSec / 60;
                int sec = TimerSec % 60;
                timer.Text = "00:"+min+":"+sec;
                if(TimerSec == 0)
                {
                    return false;
                }
                return true;
            });
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Ignore_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void getData()
        {
            mList = await App.Database.getMontageResult(did);
            list.ItemsSource = mList;
        }
    }
}