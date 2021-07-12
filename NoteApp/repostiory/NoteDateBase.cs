using NoteApp.utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.repostiory
{
    public class NoteDateBase
    {
        static Lazy<SQLiteAsyncConnection> lazyDatabaseConnection = new Lazy<SQLiteAsyncConnection>(() =>
        {

            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //SQLiteAsyncConnection  Database =new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        public SQLiteAsyncConnection Database = lazyDatabaseConnection.Value;


        public void CreateNoteInformationTable()
        {
            if (!Database.TableMappings.Any(m => m.TableName == typeof(NoteInformation).Name))
            {
                /*Create a Table table name NoteInformation*/
                Database.CreateTableAsync<NoteInformation>();
            }
        }

        public Task<List<NoteInformation>> GetNoteInfromation()
        {

            return Database.Table<NoteInformation>().ToListAsync();
        }

        public void SaveNoteInformation(NoteInformation noteInfomation)
        {

            if (noteInfomation.Id != 0)
            {

                //already have a record in side of NoteInformation table

                Database.UpdateAsync(noteInfomation);
            }
            else {
                //its new record go to insert in to a NoteInfromation Table
                Database.InsertAsync(noteInfomation);
            }
        }

        public void DeleteNoteInformation(NoteInformation noteInfomation)
        {
            Database.DeleteAsync(noteInfomation);
        }
    }
}
