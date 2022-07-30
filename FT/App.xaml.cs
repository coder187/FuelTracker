using System;
using System.IO;
using FT.Data;
using Xamarin.Forms;

namespace FT
{
    public partial class App : Application
    {
        static FT_Database database;

        // Create the database connection as a singleton.
        public static FT_Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new FT_Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FuelRecords.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}