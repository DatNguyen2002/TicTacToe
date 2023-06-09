using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                DrawBoard();

                Console.WriteLine("Player {0}'s turn. Enter a number (1-9):", currentPlayer);
                int move = Convert.ToInt32(Console.ReadLine());

                if (IsValidMove(move))
                {
                    board[move - 1] = currentPlayer;

                    if (IsWinner())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Player {0} wins!", currentPlayer);
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("It's a tie!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static void DrawBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static bool IsValidMove(int move)
        {
            if (move < 1 || move > 9)
                return false;

            if (board[move - 1] != ' ')
                return false;

            return true;
        }

        static bool IsWinner()
        {
            // Kiểm tra các hàng ngang
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == currentPlayer && board[i * 3 + 1] == currentPlayer && board[i * 3 + 2] == currentPlayer)
                    return true;
            }

            // Kiểm tra các hàng dọc
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == currentPlayer && board[i + 3] == currentPlayer && board[i + 6] == currentPlayer)
                    return true;
            }

            // Kiểm tra các đường chéo
            if ((board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }
    }
}
