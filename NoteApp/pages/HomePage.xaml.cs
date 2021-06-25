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
    public partial class HomePage : ContentPage
    {
        ObservableCollection<NoteInfomation> noteInfomations { get; set; }
        public HomePage()
        {
            InitializeComponent();
            InitDataBase();
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
                Infromation = entryInfo.Text
            };

            App.noteDateBase.SaveNoteInformation(noteInformation);

            infoPopup.IsVisible = false;
            entryInfo.Text = string.Empty;
        }
    }
}