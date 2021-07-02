using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<NoteInfomation> noteInfomations { get; set; }
        public HomePage()
        {
            InitializeComponent();
            InitDataBase();
            noteInfomations = new ObservableCollection<NoteInfomation>(App.noteDateBase.GetNoteInfromation().Result);
            lstNotes.ItemsSource = noteInfomations;
        }

        private void InitDataBase()
        {
            App.noteDateBase.CreateNoteInformationTable();
        }

        private void OpenPopUp(object sender, EventArgs e)
        {
            infoPopup.IsVisible = true;
        }

        private void SaveNoteInformation(object sender, EventArgs e)
        {
            var noteInformation = new NoteInfomation
            {
                Infromation = entryInfo.Text,
                SaveDate = DateTime.Now.Date,
                color = noteInfomations.Count / 2 > 0 ? Color.Red : Color.Green

            };

            App.noteDateBase.SaveNoteInformation(noteInformation);

            infoPopup.IsVisible = false;
            entryInfo.Text = string.Empty;
            noteInfomations = new ObservableCollection<NoteInfomation>(App.noteDateBase.GetNoteInfromation().Result);
            lstNotes.ItemsSource = noteInfomations;

        }

        private void DragStarting(object sender, DragStartingEventArgs e)
        {

        }

        private void DropOverCommand(object sender, DropEventArgs e)
        {

        }
    }
}