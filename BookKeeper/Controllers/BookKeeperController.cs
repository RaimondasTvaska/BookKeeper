using BookKeeper.Models;
using BookKeeper.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Controllers
{
    public class BookKeeperController : Controller
    {
        private IFileService _jsonFileService;
        public BookKeeperController(IFileService fileService)
        {
            _jsonFileService = fileService;
        }

        public IActionResult Index()
        {
            List<BookKeeperModel> books = _jsonFileService.GetBooks();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(BookKeeperModel model)
        {
            List<BookKeeperModel> books = _jsonFileService.GetBooks();
            books.Add(model);
            _jsonFileService.OverwriteBooksToFile(books);
            return RedirectToAction("Index");
        }
        public IActionResult List()
        {
            List<BookKeeperModel> authors = _jsonFileService.GetBooks()
            .Select(s => new BookKeeperModel() { Author = s.Author }).ToList();
            return View(authors);
        }
    }
}
