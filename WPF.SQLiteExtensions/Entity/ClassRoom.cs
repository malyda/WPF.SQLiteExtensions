using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace WPF.SQLiteExtensions.Entity
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
