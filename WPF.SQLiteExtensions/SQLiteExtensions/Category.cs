using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteExample.Abstract;
using SQLiteNetExtensions.Attributes;

namespace SQLiteExample.SQLiteExtensions
{
    /// <summary>
    /// [PrimaryKey, AutoIncrement] Id ihnerits from ATabe
    /// </summary>
    class Category : ATable
    {
        public string Text { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Note> Notes { get; set; }
    }
}
