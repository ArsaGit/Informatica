using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Informatica
{
    class Table
    {
        public int boxWidth = 2;
        public int boxHeight = 2;

        public int spaceUp = 1;
        public int spaceLeft = 1;

        public int cellHeight = 1;
        public int cellWidth = 5;

        public string number="";
        public int[] array;
        

        //ПРИМЕР 1
        //ширина поля = 2
        //высота поля = 1
        //отступ сверху = 2
        //отступ слева = 4
        //высота ячейки = 2
        //ширина ячейки = 3
        //┌ ┬ ┐ ├ ┼ ┤ └ ┴ ┘ │ ─


        public void GetTableInfo(string num)
        {
            number =num;
            boxWidth = number.Length+1;
        }
        public void GetTableInfo(int[] num)
        {
            array = num;
            boxWidth = array.Length;
        }

        public void ShowRank()
        {
            

            string[] content = new string[number.Length + 1];
            string[] rank = new string[number.Length + 1];

            boxWidth = rank.Length;
            
            rank[0] = "Ранг";
            content[0] = "Цифра";
            for (int i = 0; i < number.Length; i++)
                rank[i+1]=(number.Length-1-i).ToString();
            for (int i = 0; i < number.Length; i++)
                content[i + 1] = number[i].ToString();

            WriteBoxLine('┌', '─', '┬', '┐');
            WriteBoxLine('│', ' ', '│',rank);
            WriteBoxLine('├', '─', '┼', '┤');
            WriteBoxLine('│', ' ', '│', content);
            WriteBoxLine('└', '─', '┴', '┘');
        }

        public void ShowCCInto10cc(NumberCC a)
        {
            string[] content = new string[number.Length];
            string[] rank = new string[number.Length];
            for (int i = 0; i < number.Length; i++)
                rank[i] = (number.Length - 1 - i).ToString();
            for (int i = 0; i < number.Length; i++)
                content[i] = number[i].ToString();

            double n = 0;
            for(int i = 0; i < number.Length; i++)
            {
                if (i != 0) Console.Write("+");
                Console.Write($"{content[i]}*({a.ccBefore}^{rank[i]})");
                n += a.numericalForm[i]*Math.Pow(a.ccBefore, int.Parse(rank[i]));
                if (i == number.Length-1) Console.Write($"={n}");
            }
            Console.Write("\n");
        }

        public void Show10ccIntoRequiredCC(NumberCC a)
        {
            //вычисление кол-ва символов
            //численный вид
            var listDel = new List<string> { };
            var listOstatok = new List<string> { };
            listDel.Add("Число");
            listOstatok.Add("Остаток");
            
            int temp=a.number10CC;

            listDel.Add(temp.ToString());
            listOstatok.Add((temp % a.ccAfter).ToString());
            do
            {
                temp /= a.ccAfter;
                listDel.Add(temp.ToString());
                listOstatok.Add((temp % a.ccAfter).ToString());
                
            } while (temp >= a.ccAfter);
            boxWidth = a.numberAfter.Length+1;
            cellWidth = 7;
            WriteBoxLine('┌', '─', '┬', '┐');
            WriteBoxLine('│', ' ', '│', listDel);
            WriteBoxLine('├', '─', '┼', '┤');
            WriteBoxLine('│', ' ', '│', listOstatok);
            WriteBoxLine('└', '─', '┴', '┘');
            
            Console.Write($"\n{a.number10CC} в 10 в {a.ccAfter}={a.numberAfter} в {a.ccAfter}");
        }

        public void ShowRomanN(NumberCC a)
        {
            var listNum = new List<string> { };
            var listRoman = new List<string> { };
            listNum.Add("Разряды");
            listRoman.Add("Римские");

            boxWidth = a.numberAfter.Length + 1;
            cellWidth = 7;

            int del = 1000;
            for (int i = 6; i >= 0; i -= 2)
            {
                int n = a.number10CC / del;
                listNum.Add(n.ToString());
                int temp = a.number10CC;
                if (n != 0) listRoman.Add(NumberCC.GetRomanNumber(n, i));
                temp = temp % del;
                del /= 10;
            }
            WriteBoxLine('┌', '─', '┬', '┐');
            WriteBoxLine('│', ' ', '│', listNum);
            WriteBoxLine('├', '─', '┼', '┤');
            WriteBoxLine('│', ' ', '│', listRoman);
            WriteBoxLine('└', '─', '┴', '┘');
        }


        //вывод таблицы
        public void ShowTable()
        {

            CreateIndent('\n', spaceUp);
            WriteBoxLine('┌', '─', '┬', '┐');
            for (int i = 0; i < boxHeight; i++)
            {
                WriteBoxLine('│', ' ', '│');
                if (i == boxHeight - 1) WriteBoxLine('└', '─', '┴', '┘');
                else WriteBoxLine('├', '─', '┼', '┤');
            }
        }
        //для однотипных выводов
        public void CreateIndent(char ch, int num)
        {
            for (int i = 0; i < num; i++)
                Console.Write(ch);
        }
        public void WriteBoxLine(char beginSym,char filler, char wallSym, char endSym)
        {
            CreateIndent(' ', spaceLeft);
            Console.Write(beginSym);
            for (int i = 0; i < boxWidth; i++)
            {
                CreateIndent(filler, cellWidth);    //заполнение клетки
                if (i == boxWidth - 1) Console.Write(endSym);
                else Console.Write(wallSym);
            }
            Console.Write('\n');
        }
        public void WriteBoxLine(char beginSym,char filler,char endSym)
        {
            for (int i = 0; i < cellHeight; i++)
            {
                CreateIndent(' ', spaceLeft);
                Console.Write(beginSym);
                for (int j = 0; j < boxWidth; j++)
                {
                    CreateIndent(filler, cellWidth);    //заполнение клетки
                    Console.Write(endSym);
                }
                Console.Write('\n');
            }
        }
        public void WriteBoxLine(char beginSym, char filler, char endSym,string[] array)
        {
            for (int i = 0; i < cellHeight; i++)
            {
                CreateIndent(' ', spaceLeft);
                Console.Write(beginSym);
                for (int j = 0; j < boxWidth; j++)
                {
                        //заполнение клетки
                    Console.Write(CreateStr(array[j]));
                    Console.Write(endSym);
                }
                Console.Write('\n');
            }
        }
        public void WriteBoxLine(char beginSym, char filler, char endSym, List<string> list)
        {
            for (int i = 0; i < cellHeight; i++)
            {
                CreateIndent(' ', spaceLeft);
                Console.Write(beginSym);
                foreach(string str in list)
                {
                     //заполнение клетки
                     Console.Write(CreateStr(str));
                     Console.Write(endSym);
                }
                Console.Write('\n');
            }
        }
        public string CreateStr(string str)
        {
            if (str.Length == cellWidth) return str;
            else
            {
                string temp = new string(' ', cellWidth - str.Length);
                str = str + temp;
                return str;
            }
        }

        public int GetMaxLength(string[] a)
        {
            int length = 0;
            foreach(string str in a)
            {
                if (str.Length > length) length = str.Length;
            }
            return length;
        }
        public int GetMaxLength(List<string> a)
        {
            int length = 0;
            foreach (string str in a)
            {
                if (str.Length > length) length = str.Length;
            }
            return length;
        }


    }
}
