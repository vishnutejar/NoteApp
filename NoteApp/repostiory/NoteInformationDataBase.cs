using NoteApp.utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.repostiory
{
    public  class NoteInformationDataBase
    {
        static Lazy<SQLiteAsyncConnection> lazyDatabaseConnection = new Lazy<SQLiteAsyncConnection>(() =>
        {

            return new SQLiteAsyncConnection(Constants.DatabasePath,Constants.Flags);
        });

        public  SQLiteAsyncConnection Database = lazyDatabaseConnection.Value;

        public void CreateNoteTable()
        {
              /* if Note table already created or not */
            if (!Database.TableMappings.Any(m => m.TableName == typeof(Note).Name))
            {
                Database.CreateTableAsync<Note>();
            }
        }


        public  Task<List<Note>> GetListOfNotes() {
            return Database.Table<Note>().ToListAsync();
        }

        public Task<int> InsertNote(Note item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
    }
}
