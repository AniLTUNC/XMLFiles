using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;
using XMLFiles.Models;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBooks(string filePath)
        {
            List<Book> books = new List<Book>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList bookNodes = doc.SelectNodes("//Book");

            foreach (XmlNode bookNode in bookNodes)
            {
                Book book = new Book();
                book.Author = bookNode.SelectSingleNode("Author").InnerText;
                book.Title = bookNode.SelectSingleNode("Title").InnerText;
                book.Genre = bookNode.SelectSingleNode("Genre").InnerText;
                book.Price = decimal.Parse(bookNode.SelectSingleNode("Price").InnerText);
                book.PublishDate = bookNode.SelectSingleNode("PublishDate").InnerText;
                book.Description = bookNode.SelectSingleNode("Description").InnerText;

                books.Add(book);
            }

            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}