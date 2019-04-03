using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2.Model
{
    /// <summary>
    /// Модель класса человека.
    /// </summary>
    class People
    {
        public int PeopleId { get; set; }
        [RegularExpression(@"[MF]",ErrorMessage ="Символы для пола - только M или F!")]
        public string Gender { get; set; }
        public string FullName { get; set;}
        public int Age { get; set; }

        public int? FatherId { get; set; }
        public People Father { get; set; }
        public int? MotherId { get; set; }
        public People Mother { get; set; }
        public int? SpouseId { get; set; }
        public People Spouse { get; set; }
    }
}
