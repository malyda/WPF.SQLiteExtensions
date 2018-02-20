using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace WPF.SQLiteExtensions
{
    class Subject : ATable
    {
        public String Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Marks
        public List<Mark> Marks { get; set; }

    }
}
