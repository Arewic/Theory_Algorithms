using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[,] { { 'A', 'E', 'D' },
                                          { 'D', 'J', 'B' },
                                          { 'А', 'B', 'C' } };
            Console.WriteLine(Exist(board, "DJA"));
            Console.ReadKey();
        }
        //Число соседних ячеек 
        static int GetNumberNeighbors(char[,] table, int line, int col)
        {
            int n = table.GetLength(0);
            int m = table.GetLength(1);
            int num = 4;
            if ((line == 0 || line == n - 1) && (col == 0 || col == m - 1))
                num = 2;
            else if ((line == 0 || line == n - 1) || (col == 0 || col == m - 1))
                num = 3;
            return num;
        }
        public static bool Exist(char[,] board, string word)
        {
            if (word.Length == 0)
                return false;
            int n = board.GetLength(0);//кол-во строк 
            int m = board.GetLength(1);//кол-во столбцов
            int[] look = new int[n * m];//просмотренные буквенные ячейки
            char[] w = word.ToCharArray();
            int br, l, c, x;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == w[0])
                    {
                        br = GetNumberNeighbors(board,i,j);
                        Array.Clear(look, 0, n * m);
                        l = i; c = j; x = 0; 
                        while (true)
                        {
                            x++;
                            if (x == word.Length)
                                return true;
                            look[l * n + c] = 1;
                            if (c - 1 >= 0 && board[l, c - 1] == w[x] && look[l * n + c - 1] != 1)
                                c--;
                            else if (l - 1 >= 0 && board[l - 1, c] == w[x] && look[(l - 1) * n + c] != 1)
                                l--;
                            else if (c + 1 < m && board[l, c + 1] == w[x] && look[l * n + c + 1] != 1)
                                c++;
                            else if (l + 1 < n && board[l + 1, c] == w[x] && look[(l + 1) * n + c] != 1)
                                l++;
                            else if (br == 0)
                                break;
                            else
                            {
                                Array.Clear(look, 0, n * m);
                                l = i; c = j; x = 0; br--;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
