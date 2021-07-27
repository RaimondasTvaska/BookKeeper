using BookKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class MemoryFileService : IFileService
    {
        private List<BookKeeperModel> _books = new();
        public List<BookKeeperModel> GetBooks()
        {
            return _books;
        }

        public void OverwriteBooksToFile(List<BookKeeperModel> books)
        {
            _books = books;
        }
    }
}
