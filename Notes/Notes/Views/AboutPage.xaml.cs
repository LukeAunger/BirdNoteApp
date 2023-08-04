using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BirdApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)//Buttons that are called when users click on the xml buttons with the same name
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://aka.ms/xamarin-quickstart");
        }
        async void OnTutorialButtonClicked(object sender, EventArgs e)
        {
            //Similar to the last one but being sent to a different link 
            await Launcher.OpenAsync("https://www.wildlifetrusts.org/identify-birds-prey");
        }
        async void OnLocationButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.birdspot.co.uk/days-out/10-uk-bird-watching-spots");
        }
    }
}