using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BirdApp.Models;
using Xamarin.Forms;

namespace BirdApp.Views
{
    public partial class NotesPage : ContentPage//creating the notepage class and inheriting from contentpage
    {
        public NotesPage()//the notepage is initialized
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()//when the page is opened the on appearing method will be caled 
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)//when the add buttons clicked this method is called that will send the user to the note entry page
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)//method used to update notes
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}