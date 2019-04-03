using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_3.Model
{
    /// <summary>
    /// Класс модели валюты.
    /// </summary>
    class Valute
    {
        public string ID;
        public int NumCode;
        public string CharCode;
        public int Nominal;
        public string Name;
        public double Value;
        public double CousrePerRub
        {
            get
            {
                return Value / Nominal;
            }
        }
        public Valute(string id, int numCode, int nominal, string charCode,string name,double value)
        {
            ID = id;
            NumCode = numCode;
            Nominal = nominal;
            CharCode = charCode;
            Name = name;
            Value = value;
        }
    }
    
}
