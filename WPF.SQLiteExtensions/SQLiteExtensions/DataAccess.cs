using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using SQLiteExample.Abstract;
using SQLiteNetExtensions.Extensions;

namespace SQLiteExample.SQLiteExtensions
{
    class DataAccess
    {
        private readonly SQLiteConnection _db;

        /// <summary>
        /// Create tables and initialize database connection
        /// </summary>
        public DataAccess()
        {
            _db = new SQLiteConnection(App.DbPath);
            _db.CreateTable<Note>();
            _db.CreateTable<Category>();

        }

        public int Insert<T>(T table) where T : ATable, new ()
        {
            return _db.Insert(table);
        }

        /// <summary>
        /// Update given object with all references
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        public void UpdateWithChildren<T>(T table) where T : class, new()
        {
            _db.UpdateWithChildren(table);
        }

        /// <summary>
        /// Return all rows for given table with all references
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetAllWithChildren<T>() where T : ATable, new()
        {
            return _db.GetAllWithChildren<T>().ToList();
        }

        public List<T> GetAllWithChildrenBellowId<T>(int id) where T : ATable, new()
        {
            return _db.GetAllWithChildren<T>().Where(i => i.ID < id).ToList();
        }
    }
}
