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
        public NoteInformation current;
        public bool IsEdit;
        public AddNotePage()
        {
            InitializeComponent();
            IsEdit = false;
        }
        public AddNotePage(NoteInformation current)
        {
            InitializeComponent();
            this.current = current;
            editorNoteInformation.Text = this.current.Note;//already there in record 
            IsEdit = true;
        }

        private void SaveNote(object sender, EventArgs e)
        {
            String noteinformation = editorNoteInformation.Text;//latest Note

            if (IsEdit) {
                NoteInformation noteInformation = new NoteInformation
                {
                    Id = current.Id,
                    Note = noteinformation,
                    SaveTime = DateTime.Now

                };
                App.noteDateBase.SaveNoteInformation(noteInformation);

            }
            else
            {
                if (!string.IsNullOrEmpty(noteinformation))
                {
                    NoteInformation noteInformation = new NoteInformation
                    {
                        Note = noteinformation,
                        SaveTime = DateTime.Now

                    };
                    App.noteDateBase.SaveNoteInformation(noteInformation);
                }
            }
           
            Navigation.PopAsync();
            
        }

        private void CloseScreen(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}