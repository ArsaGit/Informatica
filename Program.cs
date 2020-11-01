using System;
using System.Globalization;
using System.Linq;

namespace Informatica
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите CC числа:");
            //int ccBefore = GetInt();
            //string numberBefore = GetNumber(ccBefore, alphabet);
            //string numberAfter = ConvertToRomanNumerals(ccBefore, numberBefore, alphabet);
            //Console.WriteLine(numberAfter);


            //float num = GetFloat();
            //Console.WriteLine(num);

            ConvertNumberToRequiredCC();

            Table t= new Table { };
            t.ShowTable();

    }
        
        static void ConvertNumberToRequiredCC()
        {
            NumberCC a=new NumberCC { };
            a.GetInfo();

            if (a.ccBefore != 10)
            {
                Console.WriteLine("---Перевод из одной ситемы счисления в другую---");
                Console.WriteLine("1. Перевеводим число в десятичную систему счисления");
                Console.WriteLine($"Для перевода в десятичную систему счисления необходимо найти сумму произведений основания {a.ccBefore} на соответствующую степень разряда");

            }

            Console.WriteLine(a.numberAfter);
        }



















        static float GetFloat()
        {
            while (true)
            {
                string str = Console.ReadLine();
                float num;
                if (float.TryParse(str, NumberStyles.Float,CultureInfo.InvariantCulture, out num)) return num;
            }
        }

        /*
        static string ConvertToRealNumber(float a)
        {
            string realNumber=new string('0',16);
            if (a < 0) realNumber = realNumber.Insert(0, "1");
            else if (a == 0) return realNumber;
            else realNumber = realNumber.Insert(0, "0");
            //избавление от -
            a = Math.Abs(a);

            //перевод целой части
            string integralPart;
            string realPart;
            if (a < 1)
            {
                //перевод дробной части
                realPart=
            }
            else
            {
                //перевод целой части
                integralPart = ConvertToRequiredCC(10, 2, ((int)a).ToString());
                //перевод дробной части

            }
            

            //перевод дробной части



            double realPart = a - integralPart;

            string tempNumber = a.ToString();


            return number;
        }
        static string ConvertRealPart(float num)
        {
            string numberStr="";

            while(num!=0 && numberStr.Length<24)
            {
                num *= 2;
                if (num >= 1)
                {
                    numberStr += "1";
                    num--;
                }
                else numberStr += "0";
            }
            return numberStr;
        }
        //static string GetOrder(string order,bool IsLessThan1)
        //{
        //    se
        //}

        */
    }
}
