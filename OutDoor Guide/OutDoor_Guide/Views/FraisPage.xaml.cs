using OutDoor_Guide.Model;
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
        List<Frais> frais;
        public FraisPage(int planID)
        {
            InitializeComponent();
            this.planID = planID;
            this.frais = new List<Frais>();
            setFraisTypes();
            updateList();
        }

        private async void updateList()
        {
            frais = await App.Database.GetFraisByPID(planID);
            FList.ItemsSource = frais;
        }

        private async void setFraisTypes()
        {
            List<TypeFrais> fraisType = await App.Database.GetAllFraisType();
            frais_type.ItemDisplayBinding = new Binding("typefrais");
            frais_type.ItemsSource = fraisType;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (frais_type.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select Type Frais", "Ok");
            }
            else if (amount.Text == null || amount.Text.ToString().Trim().Equals(""))
            {
                DisplayAlert("Opps", "Enter Montant", "Ok");
            }
            else if (quote.SelectedItem == null)
            {
                DisplayAlert("Opps", "Select Quote", "Ok");
            }
            else
            {
                String ft = (frais_type.SelectedItem as TypeFrais).typefrais;
                String amt = amount.Text.ToString();
                String qt = quote.SelectedItem.ToString();
                Frais f = new Frais();
                f.typefrais = ft;
                f.montantfrais = double.Parse(amt);
                f.chauffeurid = planID;
                f.devise = qt;

                await App.Database.SaveFrais(f);
                updateList();
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}