using SQLite;

namespace WPF.SQLiteExtensions.Entity
{
    public abstract class ATable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
