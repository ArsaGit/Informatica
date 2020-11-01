using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Informatica
{
    class NumberCC
    {
        static char[] alphabet = {
                '0','1','2','3','4','5','6','7','8','9',
                'A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T',
                'U','V','W','X','Y','Z','a','b','c','d',
                'e','f','g','h','i','j','k','l','m','n'};
        public int ccBefore=0;
        public string numberBefore="";
        public int ccAfter=0;
        public string numberAfter="";
        public int number10CC=0;
        public int[] numericalForm;
        public string romanNumber="";

        
        

        

        public void GetInfoCC()
        {
            GetCCBefore();
            GetNumberBefore();
            GetCCAfter();
            ConvertToNumericalForm();
            ConvertTo10CC();
            ConvertToRequiredCC();
            ConvertToRomanNumerals();
        }

        public void GetCCBefore()
        {
            Console.WriteLine("Введите CC числа:");
            ccBefore = GetInt();
        }
        public void GetCCAfter()
        {
            Console.WriteLine("Введите CC в которую переводится число:");
            ccAfter = GetInt();
        }
        public void GetNumberBefore()
        {
            Console.WriteLine("Введите число:");
            do
            {
                numberBefore = Console.ReadLine();
                numberBefore = numberBefore.Trim();
            } while (!IsNumberCorrect(ccBefore, numberBefore, alphabet));
        }
        public void ConvertToNumericalForm()
        {
            numericalForm = new int[numberBefore.Length];
            for (int i = 0; i < numberBefore.Length; i++)
                for (int j = 0; j < alphabet.Length; j++)
                    if (numberBefore[i] == alphabet[j]) numericalForm[i] = j;
        }
        public void ConvertTo10CC()
        {
            if (ccBefore == 10) number10CC = int.Parse(numberBefore);
            else
            {
                for (int i = 0; i < numericalForm.Length; i++)
                    number10CC += numericalForm[i] * (int)Math.Pow(ccBefore, numericalForm.Length - 1 - i);
            }
        }
        public void ConvertToRequiredCC()   //int ccBefore,int ccAfter,string number,char[] alphabet
        {
            //вычисление кол-ва символов
            int size = 1;
            int temp = number10CC;
            int temp2= number10CC;
            while (temp >= ccAfter)
            {
                size++;
                temp /= ccAfter;
            }
            //численный вид
            var numberAfterArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                numberAfterArray[size - i - 1] = temp2 % ccAfter;
                temp2 /= ccAfter;
            }
            //перевод в n-сс вид
            for (int i = 0; i < size; i++)
                numberAfter += alphabet[numberAfterArray[i]];
        }

        public void ConvertToRomanNumerals()
        {
            int del = 1000;
            for (int i = 6; i >= 0; i -= 2)
            {
                int n = number10CC / del;
                int temp = number10CC;
                if (n != 0) romanNumber += GetRomanNumber(n, i);
                temp = temp % del;
                del /= 10;
            }
        }


        static int GetInt(int x0 = 2, int x1 = 50)
        {
            while (true)
            {
                string cc = Console.ReadLine();
                int num;
                if (Int32.TryParse(cc, out num) && num >= x0 && num <= x1) return num;
            }
        }
        static bool IsNumberCorrect(int cc, string number, char[] alphabet)
        {
            int count = 0;
            foreach (char ch in number)
            {
                bool check = false;
                for (int i = 0; i < cc; i++)
                    if (ch == alphabet[i]) check = true;
                if (check) count++;
            }
            if (count == number.Length) return true;
            else return false;
        }
        public static string GetRomanNumber(int number, int index)
        {
            string[] rNs = { "I", "V", "X", "L", "C", "D", "M", "Ú" };
            string romanN = "";
            if (number == 1) romanN = romanN + rNs[index];
            if (number == 2) romanN = romanN + rNs[index] + rNs[index];
            if (number == 3) romanN = romanN + rNs[index] + rNs[index] + rNs[index];
            if (number == 4) romanN = romanN + rNs[index] + rNs[index + 1];
            if (number == 5) romanN = romanN + rNs[index + 1];
            if (number == 6) romanN = romanN + rNs[index + 1] + rNs[index];
            if (number == 7) romanN = romanN + rNs[index + 1] + rNs[index] + rNs[index];
            if (number == 8) romanN = romanN + rNs[index + 1] + rNs[index] + rNs[index] + rNs[index];
            if (number == 9) romanN = romanN + rNs[index] + rNs[index + 2];
            return romanN;
        }



        
        

    }
}
