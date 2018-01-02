using OutDoor_Guide.Model;
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
    public partial class FolderServicesPage : ContentPage
    {
        private int otid;
        List<FolderServiceResult> mList;
       

        public FolderServicesPage()
        {
            InitializeComponent();
        }

        public FolderServicesPage(int otid)
        {
            InitializeComponent();
            this.otid = otid;
            getOtDetail();
            getServiceData();
        }

        private async void getOtDetail()
        {
            try
            {
                List<Ot> ots = await App.Database.GetOTById(otid);
                Ot o = ots[0];
                var name = "";
                if(o.otdestinnom != null)
                {
                    name += o.otdestinnom;
                }
                if(o.otdestprenom != null)
                {
                    name += " " + o.otdestprenom;
                }
                clientName.Text = name;
                clientNumbers.Text = o.otnobl;
                clientNote.Text = o.otnoteinterne;
            }catch(Exception e)
            {

            }
        }

        private async void getServiceData()
        {
            mList = await App.Database.GetFolderServiceByOtID(otid);
            List.ItemsSource = mList;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem != null)
                {
                    
                    ((ListView)sender).SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            try {
                Button b = sender as Button;
                String c = b.ClassId.ToString();
                double did = double.Parse(c);
                for(int i=0; i<mList.Count; i++)
                {
                    if(mList[i].detailid.Equals(did))
                    {
                        if (mList[i].calculpoid.Equals(1))
                        {
                            Navigation.PushAsync(new LivraisonPage(did));
                        }
                        else if (mList[i].calculpoid.Equals(0))
                        {
                            Navigation.PushAsync(new MontagePage(did));
                        }
                        break;
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}