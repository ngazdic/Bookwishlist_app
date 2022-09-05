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

        public Book GetBook(int id)
        {
            return _conn.QuerySingle<Book>("SELECT * FROM BooksRead WHERE ID = @id", new { id = id });
        }

        public void UpdateBook (Book book)
        {
            _conn.Execute("UPDATE BooksRead SET Name = @name WHERE ID = @id",
             new { name = book.Name, id = book.ID });
        }

        public void InsertBook(Book bookToInsert)
        {
            _conn.Execute("INSERT INTO BooksRead (NAME) VALUES (@name);",
                new { name = bookToInsert.Name });
        }


        public void DeleteBook(Book book)
        {
            _conn.Execute("DELETE FROM BooksRead WHERE ID = @id;", new { id = book.ID });
            
        }

    }
}

