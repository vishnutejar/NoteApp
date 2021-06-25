using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp
{
    public class Note
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime SaveDate { get; set; }

        public string NoteInformation { get; set; }
    }
}
