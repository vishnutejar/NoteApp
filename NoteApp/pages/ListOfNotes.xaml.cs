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
            if (NoteDate != null)
                lstOfNotess = new ObservableCollection<NoteInformation>(NoteDate); 
           

            lstOfNotesinhome.ItemsSource = lstOfNotess;
        }

        private void EditNote(object sender, EventArgs e)
        {

        }

        private void OnItemAdded(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNotePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var NoteDate = App.noteDateBase.GetNoteInfromation().Result;
            if (NoteDate != null)
                lstOfNotess = new ObservableCollection<NoteInformation>(NoteDate);


            lstOfNotesinhome.ItemsSource = lstOfNotess;

        }
    }
}