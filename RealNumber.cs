using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Informatica
{
    class RealNumber
    {
        public float numberFloat = 0;
        public string realNumber = new string('0',16);
        public int order = 0;
        public string orderStr = "";
        public string realPart = "";
        public string integralPart = "";
        public string mantissa="";
        public NumberCC n=new NumberCC { };

        public void GetInput()
        {
            Console.WriteLine("Введите число");
            numberFloat = GetFloat();
        }
        public void ConvertToRealNumber(float a)
        {
            if (a < 0) realNumber = realNumber.Insert(0, "1");
            else realNumber = realNumber.Insert(0, "0");
            //избавление от -
            a = Math.Abs(a);

            float zaZapyatiy = a - (int)a;

            string tempNumber = "";

            //перевод целой части
            if (IsLessThan1(numberFloat))
            {
                integralPart = "0";
                //перевод дробной части
                realPart = ConvertRealPart(zaZapyatiy);
            }
            else
            {
                //перевод целой части
                n.numberBefore = ((int)a).ToString();
                n.ccBefore = 10;
                n.ccAfter = 2;
                n.ConvertToRequiredCC();
                integralPart = n.numberAfter;
                //перевод дробной части
                realPart = ConvertRealPart(zaZapyatiy);
            }
            tempNumber = integralPart + "," + realPart;

            order = GetOrder(tempNumber, IsLessThan1(numberFloat));

            n.number10CC = order;
            n.ccBefore = 10;
            n.ccAfter = 2;
            n.ConvertToRequiredCC();
            orderStr = n.numberAfter;
            orderStr = GetOrderStr(orderStr);

            mantissa = GetMantissa(tempNumber, order, IsLessThan1(numberFloat));
   
            realNumber = realNumber.Insert(1, orderStr);
            realNumber = realNumber.Insert(9, mantissa);
        }

        static string GetOrderStr(string orderStr)
        {
            string temp = new string('0', 8 - orderStr.Length);
            return temp + orderStr;
        }
        static string GetMantissa(string str, int order, bool IsLessThan1)
        {
            string str1, str2;


            int temp = str.IndexOf(',');
            str = str.Remove(str.IndexOf(',', 1));
            if (IsLessThan1)
            {
                str1 = str.Substring(0,temp + order);
                str2 = str.Substring(temp + order);
            }
            else
            {
                order -= 127;
                str1 = str.Substring(0, temp - order);
                str2 = str.Substring(temp - order);
            }
            return str2;
        }

        static string ConvertRealPart(float num)
        {
            string numberStr = "";

            while (num != 0 && numberStr.Length < 24)
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
        static int GetOrder(string number, bool IsLessThan1)
        {
            int count = 0;
            if(IsLessThan1)
            {
                for(int i=number.IndexOf(',');i<number.Length;i++)
                {
                    if (number[i] == '1') return count;
                    count++;
                }
                return 0;
            }
            else
            {
                for (int i = number.IndexOf(','); i >=0; i--)
                {
                    if (number[i] == '1') count++;
                }
                return (count + 127);
            }
        }


        public static bool IsLessThan1(float numberFloat)
        {
            if (Math.Abs(numberFloat) < 1) return true;
            else return false;
        }

        public float GetFloat()  //, 
        {
            while (true)
            {
                string str = Console.ReadLine();
                float num;
                if (float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out num)) return num;
            }
        }

    }
    
}
