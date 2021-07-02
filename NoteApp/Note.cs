using SQLite;
using System;
using System.Drawing;

namespace NoteApp
{
    public class Note
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime SaveDate { get; set; }

        public string NoteInformation { get; set; }

        public Color Color { get; }

    }
}
