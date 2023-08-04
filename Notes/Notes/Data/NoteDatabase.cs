//fetching using spaces for reacorses to be used in the code
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BirdApp.Models;
//creating a namespace and making note of the folder that it is in.
namespace BirdApp.Data
{
    public class NoteDatabase//creating a public class that will process the data for the notes page
    {
        readonly SQLiteAsyncConnection database;//connects to the database to store notes

        public NoteDatabase(string dbPath)//public class that passes in the string property
        {
            database = new SQLiteAsyncConnection(dbPath);//setting up a new instance to connect to the database
            database.CreateTableAsync<Note>().Wait();//creating a table passed from the not class and calls a wait method
        }

        public Task<List<Note>> GetNotesAsync()//creating a Task to return a valur using a system list collection with the Note class then calling a method
        {
            //Get all notes.
            return database.Table<Note>().ToListAsync();//database being returned with the table method using the Note data and another method
        }

        public Task<Note> GetNoteAsync(int id)//calling another similar method checking data against ID property stored in to the property
        {
            // Get a specific note.
            return database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)//Method for saving a note first checking that note id is not equal to 0 which will ipdate the row in a table else it will creating a new row for the new note.
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)//the delete note which will call the delete note method deleting the note variable
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}