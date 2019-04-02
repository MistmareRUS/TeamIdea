using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1.Model
{
    /// <summary>
    /// Класс модели жанра.
    /// </summary>
    class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
