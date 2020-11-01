using System;
using System.Globalization;
using System.Linq;

namespace Informatica
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Выберите действие:\n" +
            //    "1-Перевод из одной СС в другую\n" +
            //    "2-Перевод в римскую СС");
            //int key = GetInt();
            //switch (key)
            //{
            //    case 1:
            //        ConvertNumberToRequiredCC();
            //        break;
            //    case 2:
            //        ConvertToRomanN();
            //        break;
            //    default:
            //        Console.WriteLine("Некорректный ввод!");
            //        break;
            //}

            ConvertToRealNumber();

        }
        
        

        static void ConvertNumberToRequiredCC()
        {
            NumberCC a=new NumberCC { };
            a.GetInfoCC();
            var t = new Table { };
            if (a.ccBefore != 10)
            {
                Console.WriteLine("---Перевод из одной ситемы счисления в другую---");
                ConvertToNcc(t, a);
                ConvertTo10CC(t,a);
            }
            else ConvertTo10CC(t,a);
        }
        static void ConvertTo10CC(Table t, NumberCC a)
        {
            Console.WriteLine("Перевеводим число в десятичную систему счисления");
            Console.WriteLine($"Для перевода в десятичную систему счисления необходимо найти сумму произведений основания {a.ccBefore} на соответствующую степень разряда");

            t.GetTableInfo(a.numberBefore);
            t.ShowRank();
            Console.Write($"{a.numberBefore} в {a.ccBefore}сс в {a.ccAfter}cc=");
            t.ShowCCInto10cc(a);
        }
        static void ConvertToNcc(Table t, NumberCC a)
        {
            Console.WriteLine("Переводим в нужную СС:");
            Console.WriteLine("-разделить число на основание переводимой системы счисления");
            Console.WriteLine("-найти остаток от деления целой части числа");
            Console.WriteLine("-записать все остатки от деления в обратном порядке");
            t.Show10ccIntoRequiredCC(a);
        }


        static void ConvertToRomanN()
        {
            NumberCC a = new NumberCC { };
            Table t = new Table { };
            a.GetCCBefore();
            a.GetNumberBefore();
            a.ConvertToRomanNumerals();

            Console.WriteLine("---Перевод в римскую систему счисления---");
            if(a.ccBefore!=10)
            {
                Console.WriteLine("Сначала переводим в 10сс");
                ConvertTo10CC(t, a);
            }
            Console.WriteLine("Римляне, как известно, использовали для записи числа латинские буквы.\n" +
            "Считается, что римская система счисления является классическим примером непозиционной системы счисления," +
            " то есть такой системы счисления, в которой величина, которую обозначает цифра, не зависит от положения в числе.\n" +
            "Напомним, что в римской системе счисления I обозначает 1, V обозначает 5, X — 10, L — 50, C — 100, D — 500, M — 1000,Ú - 5000" +
            ".\nНапример, число 3 в римской системе счисления будет обозначаться как III.\n" +
            "Однако на самом деле не все так просто, и она не является полностью непозиционной системой счисления," +
            " потому что в римской системе счисления есть дополнительное правило, которое влияет на величину," +
            " которую обозначает цифра, в зависимости от ее положения.\n" +
            "Правило это запрещает употреблении одной и той же цифры более 3 раз подряд, поэтому три это III, а четыре это уже IV," +
            " и I(1), стоящая перед большей цифрой V(5), обозначает вычитание, то есть фактически равна -1.\n" +
            "То есть мы разделяем число на разряды(тысячи,сотни,десятки,единицы) и заменяем их на римские эквиваленты:");
            t.ShowRomanN(a);
            Console.WriteLine($"{a.numberBefore}{a.ccBefore}={a.romanNumber}");
            
        }

        static void ConvertToRealNumber()
        {
            RealNumber n=new RealNumber { };
            n.GetInput();
            n.ConvertToRealNumber(n.numberFloat);
            Console.WriteLine(n.realNumber);
        }





        static int GetInt()
        {
            while (true)
            {
                string str = Console.ReadLine();
                int num;
                if (int.TryParse(str, out num)) return num;
            }
        }

    }
}
