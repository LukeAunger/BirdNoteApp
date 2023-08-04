using System;
using System.IO;
using BirdApp.Data;
using Xamarin.Forms;

namespace BirdApp
{
    public partial class App : Application
    {
        static NoteDatabase database;

        // Create the database connection as a singleton.
        public static NoteDatabase Database
        {
            get
            {
                //pathing the image entry data to its file location for the application
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            //initializer fething the forum for resources to be placed upon too.
            InitializeComponent();
            //setting object MainPage to a new instance of the appshell class
            MainPage = new AppShell();
        }
        // protected overide which means that it cannot be overiden by a subclass or weaker access specifier
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