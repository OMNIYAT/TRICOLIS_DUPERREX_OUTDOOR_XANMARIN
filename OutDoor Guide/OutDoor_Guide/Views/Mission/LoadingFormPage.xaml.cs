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
    public partial class LoadingFormPage : ContentPage
    {
        public LoadingFormPage()
        {
            InitializeComponent();
            setupViews();
        }

        private void setupViews()
        {
            var nonScanTap = new TapGestureRecognizer();
            nonScanTap.Tapped += NonScanTap_Tapped; ;
            nonScanTap.NumberOfTapsRequired = 1;
            non_scannes.GestureRecognizers.Add(nonScanTap);

            var scanTap = new TapGestureRecognizer();
            scanTap.Tapped += ScanTap_Tapped;
            scanTap.NumberOfTapsRequired = 1;
            scannes.GestureRecognizers.Add(scanTap);
        }

        private void ScanTap_Tapped(object sender, EventArgs e)
        {
            non_scannes.BackgroundColor = Color.AliceBlue;
            non_scannes_border.BackgroundColor = Color.Black;
            scannes_border.BackgroundColor = Color.White;
            scannes.BackgroundColor = Color.White;
        }

        private void NonScanTap_Tapped(object sender, EventArgs e)
        {
            non_scannes.BackgroundColor = Color.White;
            non_scannes_border.BackgroundColor = Color.White;
            
            scannes_border.BackgroundColor = Color.Black;
            scannes.BackgroundColor = Color.AliceBlue;

            toggleViews();
        }

        private void toggleViews()
        {
            nonScanSearchText.IsVisible = !nonScanSearchText.IsVisible;
            nonScanList.IsVisible = !nonScanList.IsVisible;
            nonScanSearch.IsVisible = !nonScanSearch.IsVisible;
            verifier.IsVisible = !verifier.IsVisible;

            scanSearchText.IsVisible = !scanSearchText.IsVisible;
            scanList.IsVisible = !scanList.IsVisible;
            scanSearch.IsVisible = !scanSearch.IsVisible;
            annuler.IsVisible = !annuler.IsVisible;
        }
    }
}