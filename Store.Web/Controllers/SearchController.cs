using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {

        private readonly BookService bookService;
        
        
        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }


        // GET: SearchController
        public ActionResult Index(string query)
        {

            var books = bookService.GetAllByQuery(query);

            return View(books);
        }
    }
}
