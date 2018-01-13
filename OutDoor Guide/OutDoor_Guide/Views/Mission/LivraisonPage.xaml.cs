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
    public partial class LivraisonPage : ContentPage
    {
        private double did;
        List<LivraisonResult> mList;
        List<LivraisonResult> mScanList;

        public LivraisonPage()
        {
            InitializeComponent();
        }

        public LivraisonPage(double did)
        {
            InitializeComponent();
            setupViews();
            this.did = did;
            getNonScanData();
            getScanData();
        }

        private async void getNonScanData()
        {
            String qry = nonScanSearchText.Text != null ? nonScanSearchText.Text.ToString() : "";
            mList = await App.Database.getLivraisonNonScanResult(did,qry);
            nonScanList.ItemsSource = mList;
        }

        private async void getScanData()
        {
            String qry = scanSearchText.Text != null ? scanSearchText.Text.ToString() : "";
            mScanList = await App.Database.getLivraisonScanResult(did, qry);
            scanList.ItemsSource = mScanList;
        }

        #region setupviews
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

            nonScanSearch.Clicked += NonScanSearch_Clicked;
            scanSearch.Clicked += ScanSearch_Clicked;
            Ammuter.Clicked += Ammuter_Clicked;
            Reporter.Clicked += Reporter_Clicked; ;
            Effectuer.Clicked += Effectuer_Clicked;
        }

        private void Reporter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CausesPage());
        }

        private void Effectuer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CausesPage()); 
        }

        private void Ammuter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CausesPage());
        }

        private void ScanSearch_Clicked(object sender, EventArgs e)
        {
            getScanData();
        }

        private void NonScanSearch_Clicked(object sender, EventArgs e)
        {
            getNonScanData();
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
        #endregion 
    }
}