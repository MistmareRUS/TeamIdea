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
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
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
                new Genre( "Приключения"),
                new Genre( "Фантастика"),
                new Genre( "Детективы"),
                new Genre( "Документальная литература")
            };
            context.Genres.AddRange(Genres);
            var Books = new List<Book>
            {
                new Book("Первая книга о приключениях",1,10.0),
                new Book("Вторая книга о приключениях",1,8.50),
                new Book("Первая книга о фантастике",2,11.80),
                new Book("Вторая книга о фантастике",2,15.70),
                new Book("Третья книга о фантастике",2,9.90),
                new Book("Первая книга о детективах",3,20.00),
                new Book("Первая документальная книга",4,7.99),
                new Book("Вторая документальная книга",4,13.60),
                new Book("Третья документальная книга",4,15.40),
            };
            context.Books.AddRange(Books);
            context.SaveChanges();

            base.Seed(context);
        }
    } 
}
