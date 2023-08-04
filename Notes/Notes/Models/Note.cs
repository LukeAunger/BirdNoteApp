using System;
using SQLite;

namespace BirdApp.Models
{
    public class Note//public class created called note
    {
        [PrimaryKey, AutoIncrement]//database classes to implement how data is inserted into the tables
        //propertys setup with getters and setters 
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string FilePath { get; set; }
        public string LocalPath { get; set; }
    }
}