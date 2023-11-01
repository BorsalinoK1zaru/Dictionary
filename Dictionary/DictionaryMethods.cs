using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dictionary
{
    internal static class DictionaryMethods
    {
        //Тип словаря:
        //False - АнглоРусский
        //True - РусскоАнглийский
        // "RusAnglD.xml" - название словарей  
        // "AnglRusD.xml" - название словарей
        public static void AddWord(bool dictType)
        {
            string newWord, newVal;
            ForNewWord(out newWord, out newVal);
            if (WordInDictionary(newWord, dictType))//Доделать
            {
            DoNewRecord(newWord, newVal,dictType);
            }
            else
            {
            Console.WriteLine("Такого слово уже есть, записать его, как еще одно определение? \n 1. Да \n 2. Нет");
            var res = GetRes();
            if (res == 1) NewVal(newWord,dictType);
            }
        }
        public static void ForNewWord(out string nWord, out string nVal)
        {
            Console.WriteLine("Введите слово");
            nWord = Console.ReadLine();
            Console.WriteLine("Введите определение");
            nVal = Console.ReadLine();
            Console.WriteLine("Новое слово успешно добавлено");
        }//Получаем слово и его перевод
        public static bool WordInDictionary(string word,bool dictionaryType)
        {
            return true;
        }
        public static void DoNewRecord(string word,string val,bool dType)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load((dType) ? "RusAnglD.xml" : "AnglRusD.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            // создаем новый элемент record
            XmlElement newRecord = xDoc.CreateElement("record");
            // создаем атрибут word
            XmlAttribute nameAttr = xDoc.CreateAttribute("word");
            // создаем элемент value
            XmlElement companyElem = xDoc.CreateElement("value");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode(word);
            XmlText companyText = xDoc.CreateTextNode(val);
            //добавляем узлы
            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            // добавляем атрибут name
            newRecord.Attributes.Append(nameAttr);
            // добавляем элементы company и age
            newRecord.AppendChild(companyElem);
            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(newRecord);
            // сохраняем изменения xml-документа в файл
            xDoc.Save((dType)?"RusAnglD.xml":"AnglRusD.xml");
        }
        public static int GetRes()
        {
            while (true)
            {
                var r = Console.ReadLine();
                if ((r[0] == '1' || r[0] == '2') && r.Length == 1) return int.Parse(r);
                else Console.WriteLine("Такой команды нет, пожалуйста, выберите существующую");
            }
        }
        public static void NewWord(string newWord,bool type)
        {
            Console.WriteLine("Введите новое определение");
            var val = Console.ReadLine();
            DoNewRecord(newWord,val,type);
        }
        public static void NewVal(string word, bool type)
        {

        }
    }
}
