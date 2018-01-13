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
    public partial class LoadingFormPage : ContentPage
    {
        private List<LoadFormResult> mNonScanList;
        private List<LoadFormResult> mScanList;
        private double pid;

        public LoadingFormPage()
        {
            InitializeComponent();
        }

        public LoadingFormPage(double pid)
        {
            InitializeComponent();
            this.pid = pid;
            setupViews();
            getNonScanData();
            getScanData();
        }


        private async void getNonScanData()
        {
            String qry = nonScanSearchText.Text != null ? nonScanSearchText.Text.ToString() : "";
            mNonScanList = await App.Database.getNonScanLoadFormResult(1, pid, qry);
            nonScanList.ItemsSource = mNonScanList;
        }

        private async void getScanData()
        {
            String qry = scanSearchText.Text != null ? scanSearchText.Text.ToString() : "";
            mScanList = await App.Database.getScanLoadFormResult(pid, qry);
            scanList.ItemsSource = mScanList;
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
            if (scanList.IsVisible == true)
                return;
            non_scannes.BackgroundColor = Color.AliceBlue;
            non_scannes_border.BackgroundColor = Color.Black;

            scannes_border.BackgroundColor = Color.White;
            scannes.BackgroundColor = Color.White;

            toggleViews();
        }

        private void NonScanTap_Tapped(object sender, EventArgs e)
        {
            if (nonScanList.IsVisible == true)
                return;
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