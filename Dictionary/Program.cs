using Dictionary;
using System.Xml;

//Тип словаря:
//False - АнглоРусский
//True - РусскоАнглийский
var start = true;

while (start)
{
    Console.WriteLine("Выберите тип словаря: \n 1. Русско-английский \n 2. Англо-русский \n");
    var res =int.Parse(Console.ReadLine());
    
    switch (res)
    {
        case 1:
            MainMethod.DictionMethod(MainMethod.ChooseAction(),ref start,false);
            break;
        case 2:
            MainMethod.DictionMethod(MainMethod.ChooseAction(),ref start,true);
            break;
        default:
            MainMethod.ExceptDiction();
            start = MainMethod.GetStart();
            break;
    }
}