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
        
        public MissionPage(int planID)
        {
            InitializeComponent();
            this.planID = planID;

            Plan_ID.Text = this.planID + "";
        }
    }
}