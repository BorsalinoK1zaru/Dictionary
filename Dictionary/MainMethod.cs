using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dictionary
{
    internal static class MainMethod
    {
        public static void DictionMethod(int res,ref bool nStart,bool dictionaryType)
        {
            switch (res)
            {
                case 1:
                    //Получить определение
                    
                    nStart=GetStart();
                    break;
                case 2:
                    //Записать определение
                    DictionaryMethods.AddWord(dictionaryType);
                    nStart = GetStart();
                    break;
                case 3:
                    //Вернуться назад
                    nStart = false;
                    break;
            }
        }

        public static void ExceptDiction()
        {
            throw new Exception("Такой команды нет. Попробуйте ввести команду из перечня");
        }
        public static bool GetStart()
        {
            Console.WriteLine("Желаете продолжить работу со словарем? \n 1. Да \n 2. Нет");
            var buf = int.Parse(Console.ReadLine());
            if (buf != 1 && buf != 2) throw new Exception("Нет такой команды");
            return (buf == 1);
        } //Возвращаем режим, при котором 1-продолжение, иначе остановка программы
        public static int ChooseAction()
        {
            while (true)
            {
                Console.WriteLine("Выберете действие: \n 1. Получить определение  \n 2. Записать определение \n 3. Вернуться назад");
                var res = Console.ReadLine();
                if (res[0] >= '1' && res[0] <= '3' && res.Length == 1) return int.Parse(res);
                else Console.WriteLine("Такой команды нет, пожалуйста, выберите существующую");
            }
            
            
        }//Возвращаем число режима
        public static string GetWord()
        {
            Console.WriteLine("Введите слово, перевод которого хотите получить");
            return Console.ReadLine();
        }//Получаем слово, перевод которого хотим получить
        public static string GetVal() 
        {
            Console.WriteLine("Введите перевод введенного вами слова");
            return Console.ReadLine();
        }//Получаем перевод
        
    }
}
