using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    //service
    public class BookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

        }
        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
            {
                string isbn = query.Replace(" ", "")
                .Replace("-", "")
                .Replace("_", "")
                .ToUpper();
                return bookRepository.GetAllByIsbn(isbn);
            }
            return bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}
