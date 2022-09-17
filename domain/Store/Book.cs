using Store.Data;
using System.Text.RegularExpressions;

namespace Store
{
    //entity
    public class Book
    {
        private readonly BookDto dto;

        public int Id => dto.Id;
        //must be another type

        public string Title
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(Title)); }
                dto.Title = value.Trim();
            }

        }

        public string Isbn
        {
            get => dto.Isbn;
            set
            {
                if (TryFormatIsbn(value, out string formattedIsbn))
                {
                    dto.Isbn = formattedIsbn;
                }
                else
                {
                    throw new ArgumentException(nameof(Isbn));
                }
            }
        }
        //Author must be a separate class and this field must be AuthorId
        public string Author
        {
            get => dto.Author;
            set => dto.Author = value?.Trim();
        }

        public string Description
        {
            get => dto.Description;
            set => dto.Description = value;
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        public Book(BookDto dto)
        {
            this.dto = dto;
        }

        public static bool TryFormatIsbn(string isbn, out string formattedIsbn)
        {
            if (isbn == null)
            {
                formattedIsbn = null;
                return false;
            }

            formattedIsbn = isbn.Replace("-", "")
                .Replace("_", "")
                .Replace(" ", "")
                .ToUpper();
            bool isIsbn = Regex.IsMatch(formattedIsbn, @"^ISBN\d{10}(\d{3})?$");
            return isIsbn;
        }
        public static bool IsIsbn(string isbn)
            => TryFormatIsbn(isbn, out string _);

        public static class DtoFactory
        {
            public static BookDto Create(
                string isbn,
                string author,
                string title,
                string description,
                decimal price)
            {
                if (TryFormatIsbn(isbn, out string formattedIsbn))
                {
                    isbn = formattedIsbn;
                }
                else
                {
                    throw new ArgumentException(nameof(isbn));
                }
                if (string.IsNullOrWhiteSpace(title)) { throw new ArgumentNullException(nameof(title)); }

                return new BookDto
                {
                    Isbn = isbn,
                    Author = author?.Trim(),
                    Title = title.Trim(),
                    Description = description?.Trim(),
                    Price = price,

                };
            }
        }

        public static class Mapper
        {
            public static Book Map(BookDto dto) => new Book(dto);
            public static BookDto Map(Book domain) => domain.dto;
        }
    }
}
