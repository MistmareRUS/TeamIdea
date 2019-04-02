using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_1.Model;

namespace Test_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск приложения...");
            using (var db=new BookContext())
            {
                var rand = new Random();
                ///Временная модель магазина со списком книг и заполнением их случайным количеством в виде словаря.
                Dictionary<Book, int> Store = new Dictionary<Book, int>();
                var Genres = db.Genres.Include(g => g.Books);
                foreach (Genre g in Genres)
                {
                    for (int i = 0; i < g.Books.Count; i++)
                    {
                        int count = rand.Next(0, 10);
                        Store.Add(g.Books[i], count);
                    }
                }
                /// Перебор списка жанров и вывод на консоль переменных, указывающих количество
                /// соответствующих книг и их общую стоимость.
                for (int i = 1; i <= Genres.Count(); i++)
                {
                    int Count = 0;
                    double Sum = 0;
                    foreach (var store in Store)
                    {
                        if (store.Key.GenreId == i)
                        {
                            Count += store.Value;
                            Sum += store.Key.Price * store.Value;
                        }
                    }
                    Console.WriteLine($"Книг в жанре \"{Genres.FirstOrDefault(j => j.GenreId == i).GenreName}\" - {Count} штук, на общую сумму {Sum:0.00}.");
                }
            }
            Console.WriteLine("Конец приложения...");
            Console.ReadKey();
        }
    }
}
