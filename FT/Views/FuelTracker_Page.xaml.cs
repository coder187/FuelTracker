using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FT.Models;
using Xamarin.Forms;

namespace FT.Views
{
    public partial class FuelTracker_Page : ContentPage
    {
        public FuelTracker_Page()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the fuel records from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetFuelRecordsAsync();
            

        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(FTEntry_Page));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the Fuel Entry Page, passing the filename as a query parameter.
                //Note note = (Note)e.CurrentSelection.FirstOrDefault();
                //await Shell.Current.GoToAsync($"{nameof(FTEntry_Page)}?{nameof(FTEntry_Page.ItemId)}={fr.ID}");

                FuelRecord fr = (FuelRecord)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(FTEntry_Page)}?{nameof(FTEntry_Page.ItemId)}={fr.ID}");
            }
        }
    }
}