using System.Text.RegularExpressions;

namespace Store
{
    //entity
    public class Book
    {
        //must be another type
        public int Id { get; }

        public string Title { get; }

        public string Isbn { get; }
        //Author must be a separate class and this field must be AuthorId
        public string Author { get; }
        
        public string Description { get; }

        public decimal Price { get; }   

        public Book(int id, string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
            Description = description;
            Price = price;
        }

        internal static bool IsIsbn(string s)
        {
            if (s == null) { return false; }

            s = s.Replace("-", "")
                .Replace("_", "")
                .Replace(" ", "")
                .ToUpper();
            bool isIsbn = Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
            return isIsbn;
        }

    }
}
