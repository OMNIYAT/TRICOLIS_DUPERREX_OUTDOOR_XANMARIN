using OutDoor_Guide.Helpers;
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
    public partial class CausesPage : ContentPage
    {
        private String PID;
        private int Status;
        private bool isAll;

        public CausesPage()
        {
            InitializeComponent();
            setupdate();
        }

        public CausesPage(String pid, int status, bool isA)
        {
            this.PID = pid;
            this.Status = status;
            this.isAll = isA;
            InitializeComponent();
            setupdate();
        }

        private async void setupdate()
        {
            List<PickerModel> causes = await App.Database.getCauses();
            items.ItemsSource = causes;
            items.ItemDisplayBinding = new Binding("text");

        }
    }
}