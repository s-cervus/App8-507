using SQLite;

namespace App8.Database.Rec
{
    internal class sqlite_service
    {
        SQLiteAsyncConnection db;


        async Task db_main()
        {
            if (db != null) return;
            string route = Path.Combine(FileSystem.AppDataDirectory, "BookAddrs.db");

            db = new SQLiteAsyncConnection(route);

            await db.CreateTableAsync<Book>();
        }

        public async Task<List<Book>> GetBooks()
        {
            await db_main();
            return await db.Table<Book>().ToListAsync();
        }

        public async Task Save(Book book_i)
        {
            await db_main();

            if (book_i.id_book != 0)
                await db.UpdateAsync(book_i);
            else
                await db.InsertAsync(book_i);

        }

        public async Task Delete(Book book_o)
        {
            await db_main();
            await db.DeleteAsync(book_o);
        }

    }
}
