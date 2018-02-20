using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace WPF.SQLiteExtensions
{
    class DataAccess
    {
        private readonly SQLiteConnection _db;

        /// <summary>
        /// Create tables and initialize database connection
        /// </summary>
        public DataAccess()
        {
            _db = new SQLiteConnection("db.db3");
            _db.CreateTable<Mark>();
            _db.CreateTable<ClassRoom>();
            _db.CreateTable<Student>();
            _db.CreateTable<Subject>();

        }

        public void InsertWithChildren<T>(T table) where T : ATable, new ()
        {
            _db.InsertWithChildren(table, true);
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

        public void Update<T>(T table) where T : class, new()
        {
            _db.Update(table);
            
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

        public T GetAllWithChildren<T>(int id) where T : ATable, new()
        {
            return _db.GetWithChildren<T>(id, recursive: true);
        }

        public List<T> GetAllWithChildrenBellowId<T>(int id) where T : ATable, new()
        {
            return _db.GetAllWithChildren<T>().Where(i => i.ID < id).ToList();
        }
    }
}
