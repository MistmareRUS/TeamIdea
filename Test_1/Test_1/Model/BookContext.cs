using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1.Model
{
    /// <summary>
    /// Класс-контекст для работы с базой данных EF.
    /// </summary>
    class BookContext:DbContext
    {        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public BookContext():base("BookConnection")
        {
            Database.SetInitializer(new BookInitializer());
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
    /// <summary>
    /// Инициализатор контнкста с добавлением нескольких жанров и книг.
    /// </summary>
    class BookInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var Genres = new List<Genre>
            {
                new Genre(){GenreName= "Приключения" },
                new Genre(){GenreName= "Фантастика" },
                new Genre(){GenreName= "Детективы" },
                new Genre(){GenreName= "Документальная литература" }
            };
            context.Genres.AddRange(Genres);
            context.SaveChanges();

            var Books = new List<Book>
            {
                new Book(){BookName="Первая книга о приключениях", Genre=Genres[0],Price= 10.0 },
                new Book(){BookName="Вторая книга о приключениях", Genre = Genres[0],Price= 15.70 },
                new Book(){BookName="Первая книга о фантастике", Genre = Genres[1],Price= 11.80 },
                new Book(){BookName="Вторая книга о фантастике", Genre = Genres[1],Price= 15.70 },
                new Book(){BookName="Третья книга о фантастике",Genre = Genres[1],Price= 9.90 },
                new Book(){BookName="Первая книга о детективах", Genre = Genres[2],Price= 20.00 },
                new Book(){BookName="Первая документальная книга", Genre = Genres[3],Price= 7.99 },
                new Book(){BookName="Вторая документальная книга", Genre = Genres[3],Price= 13.60 },
                new Book(){BookName="Третья документальная книга", Genre = Genres[3],Price= 15.40 }
            };

            context.Books.AddRange(Books);           

            context.SaveChanges();
            base.Seed(context);
        }        
    } 
}
