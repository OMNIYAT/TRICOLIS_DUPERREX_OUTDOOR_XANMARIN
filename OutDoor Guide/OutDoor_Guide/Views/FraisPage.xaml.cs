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
    public partial class FraisPage : ContentPage
    {
        private int planID;
        
        public FraisPage(int planID)
        {
            InitializeComponent();
            this.planID = planID;
        }
    }
}