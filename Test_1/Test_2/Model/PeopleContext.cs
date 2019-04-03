using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2.Model
{
    /// <summary>
    /// Создание контекста данных и начальная инициализация БД при каждой загрузке
    /// </summary>
    class PeopleContext:DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public PeopleContext():base("PeopleConnection")
        {
            Database.SetInitializer(new PeopleInitializer());
        }        
    }
    class PeopleInitializer : DropCreateDatabaseAlways<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            var people = new List<People>()
                {
                    new People{Gender="M",FullName="Иванов Иван Иванович",Age=33,SpouseId=2},
                    new People{Gender="F",FullName="Иванова Татьяна Сергеевна",Age=29,SpouseId=1},
                    new People{Gender="M",FullName="Иванов Сергей Иванович",Age=1,FatherId=1,MotherId=2},
                    new People{Gender="M",FullName="Иванов Петр Иванович",Age=3,FatherId=1,MotherId=2},
                    new People{Gender="F",FullName="Иванова Мария Ивановна",Age=5,FatherId=1,MotherId=2},
                    new People{Gender="F",FullName="Петрова Анастасия Валерьевна",Age=46},
                    new People{Gender="M",FullName="Сидоров Антов Семенович",Age=49},
                    new People{Gender="F",FullName="Петрова Екатерина Антоновна",Age=15,FatherId=7,MotherId=6},
                    new People{Gender="M",FullName="петров Кирилл Антонович",Age=17,FatherId=7,MotherId=6},
                    new People{Gender="M",FullName="Никифоров Тимур Андреевич",Age=35},
                    new People{Gender="F",FullName="Никифорова Дарья Тимуровна",Age=5,FatherId=10},
                    new People{Gender="M",FullName="Семенов Константин Игоревич",Age=42,SpouseId=13},
                    new People{Gender="F",FullName="Семенова Татьяна Сергеевна",Age=43,SpouseId=12},
                    new People{Gender="M",FullName="Семенов Марат Константинович",Age=13,FatherId=12,MotherId=13},
                    new People{Gender="M",FullName="Семенов Артур Константинович",Age=16,FatherId=12,MotherId=13}
                };
            context.Peoples.AddRange(people);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
