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
    class Mark : ATable
    {
        public int Value { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjectId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Subject Subject { get; set; }


        [ForeignKey(typeof(Student))]
        public int StudentId { get; set; }

        [ManyToOne]
        public Student Student { get; set; }
    }
}
