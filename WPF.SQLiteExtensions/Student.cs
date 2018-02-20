using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace WPF.SQLiteExtensions
{
    class Student : ATable
    {
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Mark> Marks { get; set; }

        [ForeignKey(typeof(ClassRoom))]
        public int ClassRoomId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public ClassRoom ClassRoom { get; set; }
    }
}
