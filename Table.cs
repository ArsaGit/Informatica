using System;
using System.Collections.Generic;
using System.Text;

namespace Informatica
{
    class Table
    {
        public int boxWidth = 2;
        public int boxHeight = 4;

        public int spaceUp = 2;
        public int spaceLeft = 4;

        public int cellHeight = 2;
        public int cellWidth = 3;

        //ПРИМЕР 1
        //ширина поля = 2
        //высота поля = 1
        //отступ сверху = 2
        //отступ слева = 4
        //высота ячейки = 2
        //ширина ячейки = 3
        //┌ ┬ ┐ ├ ┼ ┤ └ ┴ ┘ │ ─

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





    }
}
