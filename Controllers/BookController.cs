using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using lab02.Models;

namespace lab02.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<String>();
            books.Add("HTML5 $ CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 $ CSS3 The complete Manual - Author Name Book 2");
            books.Add("HTML5 $ CSS3 The complete Manual - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/images/book3.jpg"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
           
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/images/book3.jpg"));
            var bk = books.Where(s => s.ID == id).FirstOrDefault();
            Book book = new Book();

            foreach (Book b in books)
            {
                if(b.ID == id)
                {
                    book = b;
                    break;
                }
            }
            if(book==null)
            {
                return HttpNotFound();
            }
            return View(bk);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title,string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/images/book3.jpg"));
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.ID == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            var bk = books.Where(s => s.ID == s.ID).FirstOrDefault();
            books.Remove(bk);
            books.Add(bk);
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 $ CSS3 The complete Manual1", "Author Name Book 1", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 $ CSS3 The complete Manual2", "Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "HTML5 $ CSS3 The complete Manual3", "Author Name Book 3", "/Content/images/book3.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Error Sava Data");
            }
            return View("ListBookModel", books);

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}