using System;
using System.Data;
using Bookwishlist_app.Models;
using Dapper;

namespace Bookwishlist_app
{
    public class BookRepository : IBookRepository
    {

        private readonly IDbConnection _conn;

        public BookRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        

        public IEnumerable<Book> GetAllBooks()
        {
            return _conn.Query<Book>("SELECT * FROM BooksRead;");
        }


    }
}

