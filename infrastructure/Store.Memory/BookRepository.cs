namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN0321751043",
                "D.Knuth",
                "The Art of Computer Programming",
                "The bible of all fundamental algorithms and the work" +
                " that taught many of today’s software developers most of " +
                "what they know about computer programming.—Byte, September 1995",
                212m),
            new Book(2, "ISBN9785990944510","M. Fowler","Refactoring","Like the original, " +
                "this edition explains what refactoring is; why you should refactor; " +
                "how to recognize code that needs refactoring; and how to actually do it successfully, " +
                "no matter what language you use."
                , 32.39m),
            new Book(3, "ISBN9780131103627", "B. Kernighan", "C Programming Language",
                "Just about every C programmer I respect learned C from this book." +
                " Unlike many of the 1,000 page doorstops stuffed with CD-ROMs" +
                " that have become popular, this volume is concise and powerful " +
                "(if somewhat dangerous) -- like C itself. And it was written by Kernighan himself." +
                " Need we say more?"
                ,38.89m),
            new Book(4, "ISBN1617290890",
                "The Art of Unit Testing: With Examples in .Net",
                "R. Osherove",
                "You know you should be unit testing, so why aren't you doing it?" +
                " If you're new to unit testing, if you find unit testing tedious," +
                " or if you're just not getting enough payoff for the effort you put into it," +
                " keep reading."
                ,39.88m)
        };


        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query) 
            || book.Author.Contains(query)).ToArray();
                }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }


        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;

            return foundBooks.ToArray();
        }
    }
}