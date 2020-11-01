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




            WriteBoxLine('┌', '┬', '─', '┐', 0);
            for (int i = 1; i <= boxHeight; i++)
            {
                WriteBoxLine('│', ' ', '│',i);
                if (i == boxHeight - 1) WriteBoxLine('└',  '┴', '─', '┘',i);
                else WriteBoxLine('├', '┼', '─', '┤',i);
            }
        }
        //для однотипных выводов
        public void CreateIndent(char ch, int num)
        {
            for (int i = 0; i < num; i++)
                Console.Write(ch);
        }
        public void WriteBoxLine(char beginSym,char wallSym,char filler,char endSym,int row)
        {
            Console.SetCursorPosition(spaceLeft, spaceUp+row*(cellHeight+1));
            Console.Write(beginSym);
            for (int i = 0; i < boxWidth; i++)
            {
                CreateIndent(filler, cellWidth);
                if (i == boxWidth - 1) Console.Write(endSym);
                else Console.Write(wallSym);
            }
        }
        public void WriteBoxLine(char beginSym,char filler,char endSym,int row)
        {
            for (int j = 0; j < cellHeight; j++)
            {
                Console.SetCursorPosition(spaceLeft, spaceUp + row * (cellHeight + 1)+1+j);
                Console.Write(beginSym);
                for (int i = 0; i < boxWidth; i++)
                {
                    CreateIndent(filler, cellWidth);
                    Console.Write(endSym);
                }
            }
        }





    }
}
