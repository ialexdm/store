namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 9785845919847","D.Knuth", "Art Of Programming"),
            new Book(2, "ISBN 9785990944510","M. Fowler","Refactoring"),
            new Book(3, "ISBN 9785845919755", "B. Kernighan", "C Programming Language"),
            new Book(4, "ISBN 1933988274","The Art of Unit Testing: With Examples in .Net", "R. Osherove")
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
    }
}