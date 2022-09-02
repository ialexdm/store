namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            string blank = "    ";
            bool actual = Book.IsIsbn(blank);

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456_789 0");

            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBn 123-456_7890-1-2-3");

            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxx IsBn 123-456_7890-1-2-3 yyy");

            Assert.False(actual);
        }
    }
}