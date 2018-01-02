using OutDoor_Guide.Data;
using OutDoor_Guide.Helpers;
using OutDoor_Guide.Views.Mission;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OutDoor_Guide
{
    public partial class App : Application
    {
        static Database database;
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new OutDoor_Guide.Views.LoginPage());
            MainPage = new NavigationPage(new LoadingFormPage());
        }

        //Create App level Database instance
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("OutdoorGuide.db3"));
                    database = new Database("/sdcard/Download/OutdoorGuide.db3");
                    //database.sampleData();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
