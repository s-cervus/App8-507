using SQLite;

namespace App8.Database.Rec
{
    internal class Book
    {
        [PrimaryKey]
        public int id_book { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string editorial { get; set; }
        public int units { get; set; }


    }
}
