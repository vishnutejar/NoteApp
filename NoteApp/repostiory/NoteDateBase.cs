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

        public SQLiteAsyncConnection Database = lazyDatabaseConnection.Value;


        public void CreateNoteInformationTable()
        {
            if (!Database.TableMappings.Any(m => m.TableName == typeof(NoteInfomation).Name))
            {
                Database.CreateTableAsync<NoteInfomation>();
            }
        }

        public Task<List<NoteInfomation>> GetNoteInfromation()
        {

            return Database.Table<NoteInfomation>().ToListAsync();
        }

        public void SaveNoteInformation(NoteInfomation noteInfomation)
        {

            if (noteInfomation.Id != 0)
            {

                Database.UpdateAsync(noteInfomation);
            }
            else {

                Database.InsertAsync(noteInfomation);
            }
        }

        public void DeleteNoteInformation(NoteInfomation noteInfomation)
        {
            Database.DeleteAsync(noteInfomation);
        }
    }
}
