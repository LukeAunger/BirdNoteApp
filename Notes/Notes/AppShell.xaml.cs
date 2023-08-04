using BirdApp.Views;
using Xamarin.Forms;

namespace BirdApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            //routing to the noteentry page as it isnt routed in the shell
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
        }
    }
}