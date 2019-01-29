using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Equations
 * row = i / w
 * col = i % w
 * i = c + r*w
 * 
 * col = x
 * row = y
*/

namespace Connect4_App
{
    public class Board
    {
        public static int width = 7;
        public static int height = 6;

        public static List<List<Cell>> Cells = new List<List<Cell>>();

        public static void PopulateCells()
        {
            for(int i = 0;i < width;i++)
            {
                Cells.Add(new List<Cell>());

                for(int j = 0;j < height;j++)
                {
                    Cells[i].Add(new Cell(null));
                }
            }
        }

        public static void DropChip(string colour, int col)
        {
            for(int row = height - 1;row >= 0;row--)
            {
                if(Cells[col][row].colour == null)
                {
                    Cells[col][row].colour = colour;
                    break;
                }
            }
        }

        public static bool CheckWin()
        {
            // Horizontal Win
            
            for(int col = 0;col <= width - 4;col++)
            {
                for(int row = 0;row < Cells[i].Capacity;row++)
                {
                    if(Cells[col][row].colour == Cells[col + 1][row].colour == Cells[col + 2][row].colour == Cells[col + 3][row].colour)
                    {
                        return true;
                    }
                }
            }

            // Vertical Win

            for(int col = 0;col < width;col++)
            {
                for (int row = 0; row <= height - 4;row++)
                {
                    if(Cells[col][row].colour == Cells[col][row + 1].colour == Cells[col][row + 2].colour == Cells[col][row + 3].colour)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Right Win
            for(int col = 0;col <= width - 4;col++)
            {
                for(int row = 0;row <= height - 4;row++)
                {
                    if(Cells[col][row].colour == Cells[col + 1][row + 1].colour == Cells[col + 2][row + 2].colour == Cells[col + 3][row + 3].colour)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Left Win

            for(int col = width - 4;col < width;col++)
            {
                for(int row = height - 4;row < height;row++)
                {
                    if(Cells[col][row].colour == Cells[col - 1][row - 1].colour == Cells[col - 2][row - 2].colour == Cells[col - 3][row - 3].colour)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
