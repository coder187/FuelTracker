using System;
using System.IO;
using FT.Models;
using Xamarin.Forms;

namespace FT.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class FTEntry_Page : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadFTRecord(value);
            }
        }

        public FTEntry_Page()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Fuel Record.
            BindingContext = new FuelRecord();
        }

        async void LoadFTRecord(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the fuel record and set it as the BindingContext of the page.
                FuelRecord fr = await App.Database.GetFuelRecordAsync(id);

                BindingContext = fr;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load fuel record.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var fr = (FuelRecord)BindingContext;
            fr.Date = DateTime.UtcNow;
            fr.FuelType = 1;
            fr.userId = 1;
            fr.userNote = "This is hardcoded note!";
            //fr.Reg = txtReg.Text;
            //fr.Litres = Convert.ToDouble(txtLitres.Text);
           // fr.OdoStart = Convert.ToDouble(txtStart.Text);
           // fr.OdoEnd = Convert.ToDouble(txtEnd.Text);


            //if (!string.IsNullOrWhiteSpace(note.Text))
            //{
                await App.Database.SaveFuelRecordAsync(fr);
            //}

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            var fr = (FuelRecord)BindingContext;
            await App.Database.DeleteFuelRecordAsync(fr);
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}