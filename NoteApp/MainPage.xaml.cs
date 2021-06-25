using NoteApp.repostiory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //App.Database.CreateNoteTable();

            //var note = new Note {

            //    NoteInformation = "Hi",
            //    SaveDate = DateTime.Now
            //};
            //App.Database.InsertNote(note);

            //var listOfNotes = App.Database.GetListOfNotes();
        }
    }
}
