using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteExample.Abstract;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteExample.SQLiteExtensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteExtensionsPage : ContentPage
    {
        readonly DataAccess _dataAccess = new DataAccess();

        public SQLiteExtensionsPage()
        {
            InitializeComponent();
          
            // Create base objects
            Note note = new Note()
            {
                Text = "text",
            };

            Category category = new Category()
            {
                Text = "text category"
            };


            // Insert them to database
            // Both Note and Category have AutoIncrement which is created by insertion into database
            _dataAccess.Insert(note);
            _dataAccess.Insert(category);

            // Set Category to Note
            note.Category = category;

            // Update Note with all references
            // In this case creates link between note and category from line above
            _dataAccess.UpdateWithChildren(note);

            // Get all notes where is id below 5
            List<Note> enumerable = _dataAccess.GetAllWithChildrenBellowId<Note>(5);

            // Set all notes to Category
            category.Notes = enumerable;

            // Update category with new references
            // Note.CategoryId is updated automatically
            _dataAccess.UpdateWithChildren<Category>(category);

            // Get all Notes from database
            List<Note> notes = _dataAccess.GetAllWithChildren<Note>();

            // Get all Categories from database
            List<Category> categories = _dataAccess.GetAllWithChildren<Category>();

            // Now you can use Note.Category as object references instead of plain IDs
            string categoryText = notes.First().Category.Text;

            // Or get all Categories with all notes
            List<Note> notesFromCategory = categories.Last().Notes;
        }
    }
}