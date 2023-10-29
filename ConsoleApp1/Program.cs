using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char player = 'X';

        static void Main(string[] args)
        {
            bool gameEnd = false;
            int turn = 0;
            int count = 1;

            Console.WriteLine("Игра крестики-нолики\n");
            Console.WriteLine("Игра с компьютером?(1/0)");
            int var = int.Parse(Console.ReadLine());
            PrintBoard();

            while (!gameEnd && turn < 9)
            {
                int cell;
                if (count % 2 == 0)
                {
                    cell = GetComputerMove(var);
                    count++;
                }
                else
                {
                    Console.Write($"\nХод игрока {player}. Введите номер ячейки (от 1 до 9): ");
                    cell = Convert.ToInt32(Console.ReadLine());
                    count++;
                }

                if (cell >= 1 && cell <= 9 && board[cell - 1] == ' ')
                {
                    board[cell - 1] = player;
                    turn++;
                    Console.Clear();
                    PrintBoard();

                    if (CheckWin())
                    {
                        gameEnd = true;
                        Console.WriteLine($"\nИгрок {player} победил!");
                    }
                    else if (turn == 9)
                    {
                        gameEnd = true;
                        Console.WriteLine("\nНичья!");
                    }
                    else
                    {
                        player = player == 'X' ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ход. Попробуйте еще раз.");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы выйти.");
            Console.ReadKey();
        }

        static int GetComputerMove(int var)
        {
            int move;
            if (var == 1)
            {
                Random rand = new Random();

                do
                {
                    move = rand.Next(0, 9);
                }
                while (board[move] != ' ');

                return move;
            }
            else
            {
                Console.WriteLine("Введите номер ячейки(от 1 до 9): ");
                move = Convert.ToInt32(Console.ReadLine());

                return move;
            }
        }

        static bool CheckWin()
        {
            if (board[0] != ' ' && board[0] == board[1] && board[1] == board[2])
                return true;
            else if (board[3] != ' ' && board[3] == board[4] && board[4] == board[5])
                return true;
            else if (board[6] != ' ' && board[6] == board[7] && board[7] == board[8])
                return true;
            else if (board[0] != ' ' && board[0] == board[3] && board[3] == board[6])
                return true;
            else if (board[1] != ' ' && board[1] == board[4] && board[4] == board[7])
                return true;
            else if (board[2] != ' ' && board[2] == board[5] && board[5] == board[8])
                return true;
            else if (board[0] != ' ' && board[0] == board[4] && board[4] == board[8])
                return true;
            else if (board[2] != ' ' && board[2] == board[4] && board[4] == board[6])
                return true;
            else
                return false;
        }

        static void PrintBoard()
        {
            Console.WriteLine("\n     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
            Console.WriteLine("     |     |      ");
        }
    }
}

