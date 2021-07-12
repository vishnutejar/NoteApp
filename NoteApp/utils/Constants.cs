using System;
using System.IO;

namespace NoteApp.utils
{
    public static class Constants
    {
        public const string DatabaseFilename = "NoteDb.db3";
        public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                /*  /date/localapplicationdate */
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                /* /date/localapplicationdate  +  NoteDb.db3*/
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
