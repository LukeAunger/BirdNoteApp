using System;
using System.IO;
using BirdApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BirdApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]//passing parameters into a page using urls
    public partial class NoteEntryPage : ContentPage//created noteentrypage thats inheriting from contentpage
    {
        public string ItemId//creating peroperty ItemId thats calls loadnote and passes in a stirng value which sets the value of itemid
        {
            set
            {
                LoadNote(value);
            }
        }

        public NoteEntryPage()//starting the noteentrypage
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        async void LoadNote(string itemId)//method that loads note to display on the entrypage for when the user wants to update a note it will display the note fetched from the database
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)//message that displays if the try fails
            {
                Console.WriteLine("Failed to load note.");
            }
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)//When the save button is clicked the note class will get the propertys for all the data that compiles the note, image, date and location
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.FilePath = path;
            note.LocalPath = resultLocation;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveNoteAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)//When the delete button is clicked the data binded to the note propertys removes their values and sends you back to the notepage
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        public string path = "";
        async void OnImgButtonClicked(System.Object sender, System.EventArgs e)//The method for when a user clickes the button to add an image to the entry that uses 
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);

                path = result.FullPath;
            }

        }
        public string resultLocation = "";
        async void OngpsButtonClicked(System.Object sender, System.EventArgs e)//Location method that activates when the user clickes the button the mobiles current location is recorded and then stored in resultLocation as a string
        {
            var georesult = await Geolocation.GetLocationAsync(new
            GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));//creating new instance of Geolocation
            resultLocation = $"lat: {georesult.Latitude}, lng: {georesult.Longitude}";
        }
    }
}