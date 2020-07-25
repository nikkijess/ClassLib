using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLib
{
    public class XML
    {
        //создание файла xml
        public static void Create(string filename)      //filename - путь к файлу
        {
            XDocument doc = new XDocument();

            //коллекция
            XElement library = new XElement("library", "Список товаров");
            doc.Add(library);

            //создаем элемент "data" c аттрибутом "article" и элементом "name"

            //1й элемент
            XElement data = new XElement("data");
            data.Add(new XAttribute("article", "123"));
            data.Add(new XElement("name", "Товар1"));

            doc.Root.Add(data); //добавляем элемент 1 в корень

            //2й элемент
            data = new XElement("data");
            data.Add(new XAttribute("article", "456"));
            data.Add(new XElement("name", "Товар2"));

            doc.Root.Add(data); //добавляем элемент 2 в корень

            /* Получается файл
             * <library>
             *          <data article = "123">
             *                 <name = "Товар1">
             *          </data>
             *          <data article = "456">
             *                 <name = "Товар2">
             *          </data>
             * </library>
            */

            //сохраняем документ
            doc.Save(filename);
        }

        public static void Read(string filename)
        {
            XDocument doc = XDocument.Load(filename);

            //ВСЕ элементы, отсортированные по аттрибуту "article"
            IEnumerable<XElement> dataa = doc.Root.Elements("data").OrderBy(t => t.Attribute("article").Value);

            //либо выборка элементов с фильтром
            dataa = doc.Root.Elements("data").Where(t => t.Attribute("article").Value == "123");

            foreach (XElement el in dataa)
            {
                //Выводим имя элемента и значение аттрибута
                Console.WriteLine("{0} - {1}", el.Attribute("article").Value, el.Element("name").Value);
            }

        }
    }
}
