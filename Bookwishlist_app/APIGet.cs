using System;
using Bookwishlist_app.Models;
using Newtonsoft.Json.Linq;

namespace Bookwishlist_app

{
    public class APIGet
    {
        public APIGet()
        {
        }



        public HttpClient client = new HttpClient();




        public IEnumerable<Book> SearchBooks (string searchstring)
        {

           
           

            var endpoint = "https://www.googleapis.com/books/v1/volumes?q=${searchstring}";
            var result = client.GetStringAsync(endpoint).Result;
            var json = JObject.Parse(result);
            var booksList = json["items"];
            IEnumerable<Book> books = booksList.Select(p => new Book
            {

                Name = (string?)p["volumeInfo"]["title"]

            }) ;

            return books;

        }

    }


   
}

