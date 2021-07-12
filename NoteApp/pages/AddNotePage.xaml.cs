using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotePage : ContentPage
    {
        public AddNotePage()
        {
            InitializeComponent();
        }

        private void SaveNote(object sender, EventArgs e)
        {
            String noteinformation = editorNoteInformation.Text;
            if (!string.IsNullOrEmpty(noteinformation))
            {
                NoteInformation noteInformation = new NoteInformation
                {
                    Note = noteinformation,
                    SaveTime = DateTime.Now

                };
                App.noteDateBase.SaveNoteInformation(noteInformation);
            }
           
            Navigation.PopAsync();
            
        }

        private void CloseScreen(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}