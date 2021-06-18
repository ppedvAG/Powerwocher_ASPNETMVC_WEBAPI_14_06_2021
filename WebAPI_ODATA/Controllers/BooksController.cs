using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ODATA.Data;
using WebAPI_ODATA.Models;

namespace WebAPI_ODATA.Controllers
{
    public class BooksController : ODataController
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }


        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }
    }

    public static class DataSource
    {
        private static IList<Book> _books { get; set; }

        public static IList<Book> GetBooks()
        {
            if (_books != null)
            {
                return _books;
            }

            _books = new List<Book>();

            // book #1
            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C#5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address { City = "Redmond", Street = "156TH AVE NE" },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            _books.Add(book);

            // book #2
            book = new Book
            {
                Id = 2,
                ISBN = "063-6-920-02371-5",
                Title = "Enterprise Games",
                Author = "Michael Hugos",
                Price = 49.99m,
                Location = new Address { City = "Bellevue", Street = "Main ST" },
                Press = new Press
                {
                    Id = 2,
                    Name = "O'Reilly",
                    Category = Category.EBook,
                }
            };
            _books.Add(book);

            return _books;
        }
    }
}
