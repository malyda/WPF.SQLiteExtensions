using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.SQLiteExtensions
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DataAccess _dataAccess = new DataAccess();

        public MainWindow()
        {
            InitializeComponent();
            InsertAsOne();
        }


        public void InsertAsOne()
        {
            Student student = new Student()
            {
                Name = "Jan Novák",
                ClassRoom = new ClassRoom()
                {
                    Name = "3ITB"
                },
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Value = 1,
                        Subject = new Subject()
                        {
                            Name = "ČJ"
                        }
                    }
                }
            };

            _dataAccess.InsertWithChildren(student);

            _dataAccess.UpdateWithChildren(student);

            Student students = _dataAccess.GetAllWithChildren<Student>(student.ID);
        }

        public void InsertOneByOneAndUpdate()
        {
            Student student = new Student()
            {
                Name = "Jan Novák"
            };

            ClassRoom classRoom = new ClassRoom()
            {
                Name = "3ITB"
            };

            Subject subject = new Subject()
            {
                Name = "ČJ"
            };

            Mark mark = new Mark()
            {
                Value = 1
            };

            _dataAccess.InsertWithChildren(student);
            _dataAccess.InsertWithChildren(classRoom);

            student.ClassRoom = classRoom;
            _dataAccess.UpdateWithChildren(student);

            _dataAccess.InsertWithChildren(mark);
            _dataAccess.InsertWithChildren(subject);

            mark.Subject = subject;
            mark.Value = 2;

            _dataAccess.UpdateWithChildren(mark);


            student.Marks = new List<Mark>()
            {
                mark
            };

            _dataAccess.UpdateWithChildren(student);

            Student students = _dataAccess.GetAllWithChildren<Student>(student.ID);
        }
    }
}
