using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WPF.SQLiteExtensions
{
    /// <summary>
    /// [PrimaryKey, AutoIncrement] Id ihnerits from ATabe
    /// </summary>
    class ClassRoom : ATable
    {
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Student> Students { get; set; }
    }
}
