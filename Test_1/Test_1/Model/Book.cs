using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1.Model
{
    /// <summary>
    /// Класс модели книги.
    /// </summary>
    class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }

        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
