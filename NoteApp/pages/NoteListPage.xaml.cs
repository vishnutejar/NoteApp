using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListPage : ContentPage
    {
        IList<Note> lstData { get; set; } 
        public NoteListPage()
        {
            InitializeComponent();
            //creating Table ex:Note
            App.Database.CreateNoteTable();
            //getting data from datebase
             lstData= App.Database.GetListOfNotes().Result;
            lstOfNoteDate.ItemsSource = lstData;
        }

        private void AddNote(object sender, EventArgs e)
        {
            notepopup.IsVisible = true;

        }

        private void SaveNote(object sender, EventArgs e)
        {
            var note = new Note() 
            {
                NoteInformation = noteentry.Text,
                SaveDate = DateTime.Now
             };
            App.Database.InsertNote(note);
            noteentry.Text = string.Empty;
            notepopup.IsVisible = false;

            lstData= App.Database.GetListOfNotes().Result;
            lstOfNoteDate.ItemsSource = lstData;

        }
    }
}