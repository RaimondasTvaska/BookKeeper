using BookKeeper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookKeeper.Services
{
    public class JsonFileService : IFileService
    {
        private const string DATA_URL = "./Books/Books.json";
        public List<BookKeeperModel> GetBooks()
        {
            if (!System.IO.File.Exists(DATA_URL))
            {
                System.IO.File.WriteAllText(DATA_URL, "[]");
            }

            string itemsText = System.IO.File.ReadAllText(DATA_URL);
            return JsonConvert.DeserializeObject<List<BookKeeperModel>>(itemsText);
        }
        public void OverwriteBooksToFile(List<BookKeeperModel> books)
        {
            string itemsText = JsonConvert.SerializeObject(books);
            System.IO.File.WriteAllText(DATA_URL, itemsText);
        }
    }
}
