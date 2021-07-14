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
    public partial class ListOfNotes : ContentPage
    {
      public  ObservableCollection<NoteInformation> lstOfNotess { get; set; }
         
        public ListOfNotes()
        {
            InitializeComponent();
             App.noteDateBase.CreateNoteInformationTable();

           var NoteDate= App.noteDateBase.GetNoteInfromation().Result;
            if (NoteDate != null) {
                lstOfNotess = new ObservableCollection<NoteInformation>(NoteDate);
                lstOfNotesinhome.ItemsSource = lstOfNotess;
            }
               
        }

        private void EditNote(object sender, EventArgs e)
        {

            var editButton = sender as Button;
            var data = editButton.BindingContext as NoteInformation;
        }

        private void OnItemAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNotePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
                    /*getting data from Sqlite db */
            var NoteDate = App.noteDateBase.GetNoteInfromation().Result;
                /*setting my date to dataset where my data getting frm Table called NoteInformation*/
            if (NoteDate != null)
                lstOfNotess = new ObservableCollection<NoteInformation>(NoteDate);

            /*binding to collection view */
            lstOfNotesinhome.ItemsSource = lstOfNotess;

        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var previous = e.PreviousSelection;
            NoteInformation current = e.CurrentSelection.FirstOrDefault() as NoteInformation;

            Navigation.PushAsync(new AddNotePage(current));
        }

        private void DeleteNote(object sender, EventArgs e)
        {
            var editButton = sender as Button;
            var data = editButton.BindingContext as NoteInformation;
            App.noteDateBase.DeleteNoteInformation(data);

            lstOfNotess.Clear();
            var NoteDate = App.noteDateBase.GetNoteInfromation().Result;
            /*setting my date to dataset where my data getting frm Table called NoteInformation*/
            if (NoteDate != null)
                lstOfNotess = new ObservableCollection<NoteInformation>(NoteDate);

            /*binding to collection view */
            lstOfNotesinhome.ItemsSource = lstOfNotess;
        }
    }
}