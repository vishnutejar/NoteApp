using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NoteApp
{
   public class NoteInfomation
    {
        [PrimaryKey,AutoIncrement]
        public int Id{ get; set; }

        public String Infromation { get; set; }

        public DateTime SaveDate { get; set; }
       public Color color { set; get; }
    }
}
