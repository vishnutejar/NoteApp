using NoteApp.pages;
using NoteApp.repostiory;
using Xamarin.Forms;

namespace NoteApp
{
    public partial class App : Application
    {
        //static NoteInformationDataBase database;
        //public static NoteInformationDataBase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new NoteInformationDataBase();
        //        }
        //        return database;
        //    }
        //}

        static NoteDateBase noteDate;
        public static NoteDateBase noteDateBase
        {
            get
            {
                if (noteDate == null)
                {
                    noteDate = new NoteDateBase();
                }
                return noteDate;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListOfNotes());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
