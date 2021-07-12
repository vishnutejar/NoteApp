using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp
{
  public class NoteInformation
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public string Note { get; set; }
        public DateTime SaveTime { get; set; }
    }
}
