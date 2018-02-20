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
    class Note : ATable
    {
        public String Text { get; set; }

        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [ManyToOne]      // Many to one relationship with Stock
        public Category Category { get; set; }
    }
}
