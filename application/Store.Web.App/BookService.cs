using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    //service
    public class BookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

        }
        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {
            var books = Book.IsIsbn(query)
                ? bookRepository.GetAllByIsbn(query)
                : bookRepository.GetAllByTitleOrAuthor(query);

            return books
                .Select(Map)
                .ToArray();
        }

        public BookModel GetById(int id)
        {
            var book = bookRepository.GetById(id);
            return Map(book);
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.Isbn,
                Price = book.Price,
                Description = book.Description,
            };
        }
    }
}
