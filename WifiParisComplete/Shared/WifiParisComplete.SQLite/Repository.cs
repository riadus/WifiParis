using System;
using System.Collections.Generic;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using WifiParisComplete.Data;

namespace WifiParisComplete.SqLite
{
    public class Repository<T> : IRepository<T> where T : SavableData, new()
    {
        protected readonly SQLiteConnection _connection;

        public Repository (SQLiteConnection connection)
        {
            _connection = connection;
        }
        public int DeleteAll ()
        {
            return _connection.DeleteAll<T> ();
        }

        public IEnumerable<T> GetAll ()
        {
            return _connection.GetAllWithChildren<T> ();
        }

        public void Save (IEnumerable<T> items)
        {
            _connection.InsertAllWithChildren (items, true);
        }
    }
}
