using System;
using Bookwishlist_app.Models;

namespace Bookwishlist_app
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
    }

    
}

