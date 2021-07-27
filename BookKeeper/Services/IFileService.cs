using BookKeeper.Models;
using System.Collections.Generic;

namespace BookKeeper.Services
{
    public interface IFileService
    {
        List<BookKeeperModel> GetBooks();
        void OverwriteBooksToFile(List<BookKeeperModel> books);
    }
}