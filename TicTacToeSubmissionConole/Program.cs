using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;


namespace TicTacToeSubmissionConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.SetCursorPosition(20, 2);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Tic Tac Toe");
            Console.ForegroundColor = oldColor;

            // calling the TicTacToe method to start the game
            var game = new TicTacToe(); 

            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Thank you for playing the game.");
            Console.ReadLine();
        }
    }
    }

