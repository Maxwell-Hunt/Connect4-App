using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

/* Equations
 * row = i / w
 * col = i % w
 * i = c + r*w
 * 
 * col = x
 * row = y
*/

namespace Connect4_App.Core
{
    public static class Board
    {
        public static int width = 7;
        public static int height = 6;

        public static List<List<Cell>> cells = new List<List<Cell>>();

        public static void PopulateCells()
        {
            for (int i = 0; i < width; i++)
            {
                cells.Add(new List<Cell>());

                for (int j = 0; j < height; j++)
                {
                    cells[i].Add(new Cell(null));
                }
            }
        }

        public static void Reset(MainPage page)
        {
            cells = new List<List<Cell>>();
            PopulateCells();
            for(int row = 0;row < height; row++)
            {
                for(int col = 0;col < width; col++)
                {
                    string g = "grid" + col.ToString() + row.ToString();
                    (page.FindName(g) as Rectangle).Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);
                }
            }
        }

        public static bool DropChip(MainPage page, string colour, int col)
        {

            for (int row = height - 1; row >= 0; row--)
            {
                if (cells[col][row].colour == null)
                {
                    cells[col][row].colour = colour;
                    string g = "grid" + col.ToString() + row.ToString();

                    if (colour == "red")
                    {
                        (page.FindName(g) as Rectangle).Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    else
                    {
                        (page.FindName(g) as Rectangle).Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                    }
                    return true;
                }
            }
            return false;
        }

        public static bool CheckWin(MainPage page)
        {
            // Horizontal Win

            for (int col = 0; col <= width - 4; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    if (cells[col][row].colour != null && cells[col][row].colour == cells[col + 1][row].colour && cells[col][row].colour == cells[col + 2][row].colour && cells[col][row].colour == cells[col + 3][row].colour)
                    {
                        return true;
                    }
                }
            }

            // Vertical Win

            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row <= height - 4; row++)
                {
                    if (cells[col][row].colour != null && cells[col][row].colour == cells[col][row + 1].colour && cells[col][row].colour == cells[col][row + 2].colour && cells[col][row].colour == cells[col][row + 3].colour)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Left Win
            for (int col = 0; col <= width - 4; col++)
            {
                for (int row = 0; row <= height - 4; row++)
                {
                    if (cells[col][row].colour != null && cells[col][row].colour == cells[col + 1][row + 1].colour && cells[col][row].colour == cells[col + 2][row + 2].colour && cells[col][row].colour == cells[col + 3][row + 3].colour)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Right Win

            for (int col = 0; col <= width - 4; col++)
            {
                for (int row = 3; row < height; row++)
                {
                    if (cells[col][row].colour != null && cells[col][row].colour == cells[col + 1][row - 1].colour && cells[col][row].colour == cells[col + 2][row - 2].colour && cells[col][row].colour == cells[col + 3][row - 3].colour)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
