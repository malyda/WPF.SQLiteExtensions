using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace WPF.SQLiteExtensions.Entity
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
