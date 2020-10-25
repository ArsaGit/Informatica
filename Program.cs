using System;
using System.Linq;

namespace Informatica
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = {
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T',
                'U','V','W','X','Y','Z','a','b','c','d',
                'e','f','g','h','i','j','k','l','m','n'
            };

            //Console.WriteLine("Введите CC числа:");
            //int ccBefore = GetInt();

            //string numberBefore = GetNumber(ccBefore,alphabet);

            //Console.WriteLine("Введите CC в которую переводится число:");
            //int ccAfter = GetInt();

            //string numberAfter = ConvertToRequiredCC(ccBefore, ccAfter, numberBefore, alphabet);
            //Console.WriteLine($"{numberBefore} в {ccBefore} = {numberAfter} в {ccAfter}");



            //Console.WriteLine("Введите CC числа:");
            //int ccBefore = GetInt();

            //string numberBefore = GetNumber(ccBefore, alphabet);
            //string numberAfter = ConvertToRomanNumerals(ccBefore, numberBefore, alphabet);
            //Console.WriteLine(numberAfter);



            float num = GetFloat();

        }
        static int GetInt(int x0=2,int x1=50)
        {
            while(true)
            {
                string cc = Console.ReadLine();
                int num;
                if (Int32.TryParse(cc,out num) && num>=x0&&num<=x1) return num;
            }
        }
        static string GetNumber(int cc,char[] alphabet)
        {
            string num;
            Console.WriteLine("Введите число:");
            do
            {
                num = Console.ReadLine();
                num = num.Trim();
            } while (!IsNumberCorrect(cc, num,alphabet));
            return num;
        }
        static bool IsNumberCorrect(int cc,string number,char[] alphabet)
        {
            int count = 0;
            foreach (char ch in number)
            {
                bool check=false;
                for(int i=0;i<cc;i++)
                    if (ch == alphabet[i]) check = true;
                if (check) count++;
            }
            if (count == number.Length) return true;
            else return false;
        }
        static int[] ConvertToNumericalForm(string number,char[] alphabet)
        {
            var numberArray = new int[number.Length];
            for(int i=0;i< number.Length;i++)
                for(int j=0;j<alphabet.Length;j++)
                    if (number[i] == alphabet[j]) numberArray[i] = j;
            return numberArray;
        }
        static int ConvertTo10CC(int ccBefore,string number,char[] alphabet)
        {
            if (ccBefore == 10) return int.Parse(number);
            int[] numberArray = ConvertToNumericalForm(number, alphabet);
            //numberArray = ReverseArray(numberArray);
            int number10CC=0;
            for(int i=0;i<numberArray.Length;i++)
                number10CC += numberArray[i] * (int)Math.Pow(ccBefore, numberArray.Length - 1 - i);
            return number10CC;
        }
        static string ConvertToRequiredCC(int ccBefore,int ccAfter,string number,char[] alphabet)
        {
            //перевод в 10сс
            int number10CC = ConvertTo10CC(ccBefore,number, alphabet);
            //вычисление кол-ва символов
            int size = 1;
            int temp = number10CC;
            while (temp >= ccAfter)
            {
                size++;
                temp /= ccAfter;
            }
            //численный вид
            var numberAfter = new int[size];
            for(int i=0;i<size;i++)
            {
                numberAfter[size - i - 1] = number10CC % ccAfter;
                number10CC /= ccAfter;
            }
            //перевод в n-сс вид
            string numberStr = "";
            for (int i = 0; i < size; i++)
                numberStr += alphabet[numberAfter[i]];
            return numberStr;
        }

        static string ConvertToRomanNumerals(int ccBefore,string numberBefore,char[] alphabet)
        {
            
            int number10CC = ConvertTo10CC(ccBefore, numberBefore, alphabet);
            string numberAfter = "";
            int del=1000;
            for(int i=6;i>=0;i-=2)
            {
                int n = number10CC / del;
                if(n!=0)numberAfter += GetRomanNumber(n,i);
                number10CC = number10CC % del;
                del /= 10;
            }
            return numberAfter;
        }
        static string GetRomanNumber(int number,int index)
        {
            string[] rNs = { "I", "V", "X", "L", "C", "D", "M", "Ú" };
            string romanN="";
            if (number == 1) romanN = romanN + rNs[index];
            if (number == 2) romanN = romanN + rNs[index] + rNs[index];
            if (number == 3) romanN = romanN + rNs[index] + rNs[index] + rNs[index];
            if (number == 4) romanN = romanN + rNs[index]+rNs[index+1];
            if (number == 5) romanN = romanN + rNs[index+1];
            if (number == 6) romanN = romanN + rNs[index+1]+rNs[index];
            if (number == 7) romanN = romanN + rNs[index+1]+ rNs[index] + rNs[index];
            if (number == 8) romanN = romanN + rNs[index+1] + rNs[index] + rNs[index] + rNs[index];
            if (number == 9) romanN = romanN + rNs[index]+rNs[index+2];
            return romanN;
        }

        static float GetFloat()
        {
            while (true)
            {
                string str = Console.ReadLine();
                float num;
                if (float.TryParse(str, out num)) return num;
            }
        }


    }
}
