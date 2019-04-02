using System;
using System.Collections.Generic;
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
                ///Получение списка моделей из БД.
                var rand = new Random();
                var Books = db.Books.ToList();
                var Genres = db.Genres.ToList();
                ///Временная модель магазина со списком книг и заполнением их случайным количеством.
                Dictionary<Book, int> Store = new Dictionary<Book, int>();
                foreach (var item in Books)
                {
                    int count = rand.Next(0, 10);
                    Store.Add(item, count);
                }
                ///Перебор списка жанров и вывод на консоль переменных, указывающих количество
                ///соответствующих книг и их общую стоимость.
                for (int i = 1; i <= Genres.Count(); i++)
                {
                    int Count = 0;
                    double Sum = 0;
                    foreach (var item in Store)
                    {
                        if (item.Key.GenreId == i)
                        {
                            Count += item.Value;
                            Sum += item.Key.Price * item.Value;
                        }
                    }
                    Console.WriteLine($"Книг в жанре \"{Genres.FirstOrDefault(j=> j.GenreId == i).GenreName}\" - {Count} штук, на общую сумму {Sum:0.00}.");
                }
            }
            Console.WriteLine("Конец приложения...");
            Console.ReadKey();
        }
    }
}
