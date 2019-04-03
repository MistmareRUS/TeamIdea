using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Test_3.Model;

namespace Test_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Загрузка курсов валют...");
            var Valutes = new List<Valute>();//Список валют, полученный из XML файла.
            var doc = new XmlDocument();
            doc.LoadXml(new WebClient().DownloadString("http://www.cbr.ru/scripts/XML_daily.asp"));
            foreach (XmlNode node in doc.DocumentElement)///заполнения списка циклом по узлам XML документа.
            {
                string ID = node.Attributes[0].Value;
                int NumCode = int.Parse(node["NumCode"].InnerText);
                string CharCode = node["CharCode"].InnerText;
                int Nominal = int.Parse(node["Nominal"].InnerText);
                string Name = node["Name"].InnerText;
                double Value = double.Parse(node["Value"].InnerText);
                Valutes.Add(new Valute(ID, NumCode, Nominal, CharCode, Name, Value));
            }

            Valute MinVal = Valutes.FirstOrDefault(v=>v.CousrePerRub==Valutes.Min(c => c.CousrePerRub)) ;
            Valute MaxVal = Valutes.FirstOrDefault(v => v.CousrePerRub == Valutes.Max(c => c.CousrePerRub));

            Console.WriteLine("Минимальная стоимость у валюты - " + MinVal.Name + ". " + MinVal.CousrePerRub + " за рублй за единицу.");
            Console.WriteLine("Максимальная стоимость у валюты - " + MaxVal.Name + ". " + MaxVal.CousrePerRub + " за рублей за единицу.");

            
            Console.ReadKey();
        }
    }
}
