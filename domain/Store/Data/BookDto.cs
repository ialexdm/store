using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Isbn { get; internal set; }
        public string Author { get; internal set; }
        public string Description { get; internal set; }
        public decimal Price { get; internal set; }
        public string Title { get; internal set; }
    }
}
