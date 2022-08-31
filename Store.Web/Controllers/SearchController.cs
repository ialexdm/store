using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {

        private readonly IBookRepository bookRepository;
        
        
        public SearchController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        // GET: SearchController
        public ActionResult Index(string query)
        {

            var books = bookRepository.GetAllByTitle(query);

            return View(books);
        }
    }
}
