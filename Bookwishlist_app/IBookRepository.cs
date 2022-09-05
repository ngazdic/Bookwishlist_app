using System;
using System.Data;
using Bookwishlist_app.Models;
using Dapper;

namespace Bookwishlist_app
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBook(int id);
        public void UpdateBook(Book book);
        public void InsertBook(Book bookToInsert);
        public void DeleteBook(Book book);


    }


}

