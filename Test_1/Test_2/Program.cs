using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_2.Model;

namespace Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт приложения...");
            using (var db = new PeopleContext())
            {
                ///Получение списка людей из БД.
                var people = db.Peoples.ToArray();

                ///Поиск отца наибольшего количества детей.
                int MaxChild = 0;
                int MaxChild_sFatherID = 0;
                for (int i = 0; i < people.Length; i++)
                {
                    if (people[i].Gender == "M")
                    {
                        int children = 0;
                        for (int j = 0; j < people.Length; j++)
                        {
                            if (people[i].PeopleId == people[j].FatherId)
                            {
                                children++;
                            }
                        }
                        if (children > MaxChild)
                        {
                            MaxChild = children;
                            MaxChild_sFatherID = people[i].PeopleId;
                        }
                    }
                }
                Console.WriteLine("Отец самого большого количества детей - " + people.FirstOrDefault(p => p.PeopleId == MaxChild_sFatherID).FullName + ". " + MaxChild + " детей.");

                ///Поиск семей с более, чем 3-мя детьми.
                int ChildCount = 3;//Перменная, указывающая порог для соответсвия запросу.
                List<People> family = new List<People>();//переменная для всех людей с более, чем 3-мя детьми.
                for (int i = 0; i < people.Length; i++)//
                {
                    int children = 0;
                    for (int j = 0; j < people.Length; j++)
                    {
                        if (people[i].PeopleId == people[j].FatherId || people[i].PeopleId == people[j].MotherId)
                        {
                            children++;
                        }
                    }
                    if (children >= ChildCount)
                    {
                        family.Add(people[i]);
                    }
                }
                foreach (var man in family.Where(p => p.Gender =="M"))///Перебор мужчин.
                {
                    bool married = false;                   
                    foreach (var woman in family.Where(p => p.SpouseId == man.PeopleId))///Если он женат-вывод информации о семье, иначе только о нем.
                    {
                        Console.WriteLine("Семья " + man.FullName + " и " + woman.FullName + " имеют более 3х детей.");
                        married = true;
                    }
                    if (!married)
                    {
                        Console.WriteLine(man.FullName+" имеет более 3х детей.");
                    }
                }
                foreach (var woman in family.Where(p => p.Gender == "F").Where(p=>p.SpouseId==null))///Перебор оставшихся женщин (незамужних).
                {
                    Console.WriteLine(woman.FullName + " имеет более 3х детей.");
                }

                ///Поиск матери с наименьшей разницей с возрастом ребенка.
                int MinDiff = 100;
                People CurrentMother = null;
                foreach (var women in people.Where(p=>p.Gender=="F"))
                {
                    foreach (var children in people.Where(c=>c.MotherId==women.PeopleId))
                    {
                        if ((women.Age - children.Age) < MinDiff)
                        {
                            MinDiff = (women.Age - children.Age);
                            CurrentMother = women;
                        }
                    }
                }
                Console.WriteLine("Наименьшая разница в возрасте с ребенком - это "+CurrentMother.FullName+". Разница "+MinDiff+" года.");

                ///Поиск детей из неполных семей
                Console.WriteLine("Дети из неполных семей:");
                foreach (var child in people.Where(c=>c.Age<18&&(c.MotherId==null||c.FatherId==null)))
                {
                    Console.WriteLine(child.FullName);
                }
            }
            Console.WriteLine("Конец приложения...");
            Console.ReadKey();
        }
    }
}
