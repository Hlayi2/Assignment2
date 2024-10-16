using System;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConsole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;

        private char[,] board =
        {
            { '-', '-', '-' },
            { '-', '-', '-' },
            { '-', '-', '-' }
        };

        private char currentPlayer = 'X';
        private int turns = 0;

        public TicTacToe()
        {
            // Inintializing the boardRender and start the game loop.
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
            Run(); 
        }

        // main loop of the game, it loops until the game comes to an end where a player wins or the game is a draw.
        public void Run()
        {
            bool gameWon = false;
            bool gameDraw = false;

            while (!gameWon && !gameDraw)
            {
                DisplayBoard();
                GetPlayerMove();
                gameWon = CheckForWin();
                gameDraw = CheckForDraw();

                if (!gameWon && !gameDraw)
                {
                    SwitchPlayer();
                }
            }

            DisplayBoard(); 

            if (gameWon)
            {
                Console.WriteLine($"Congratulations! Player {currentPlayer} wins!");
            }
            else if (gameDraw)
            {
                Console.WriteLine("It's a draw! Good game!");
            }
        }
        // Displays the current state of the board.
        private void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("Current Board:");

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine($" {board[row, 0]} | {board[row, 1]} | {board[row, 2]} ");
                if (row < 2) Console.WriteLine("---|---|---");
            }
        }

        // Method to get the player's move
        private void GetPlayerMove()
        {
            int row,  col;
            bool validMove = false;

            while (!validMove)
            {

                

                //prompt for row.
                Console.SetCursorPosition(2, 9);
                Console.Write($"Player {currentPlayer}, enter  the row[0-2] ");
               bool validRowInput = int.TryParse( Console.ReadLine(), out row);


                //prompt for column.
                Console.SetCursorPosition(2, 10);
                Console.Write($"Player {currentPlayer}, enter  the column[0-2] ");
               bool ValidColunmInput = int.TryParse( Console.ReadLine(),out col);

                

               
                // validating the row and column input.
                if (validRowInput && ValidColunmInput)

                {
                
                    validMove = UpdateBoard(row, col);
                    if (!validMove)
                    {
                        // displays an error and an invalid input/s
                        Console.Clear();
                        DisplayBoard();
                        Console.SetCursorPosition(2, 11);
                        Console.WriteLine("Oohh That spot is already taken. Try again");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.SetCursorPosition(2, 11);
                    Console.WriteLine("Invalid input! Please enter correct inputs from [0-2]");
                    Console.ReadKey();
                }
            }
            turns++;
        }

        private bool UpdateBoard(int row, int col)

            // updating the board with the player's move if the move is valid.
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;

                
                _boardRenderer.AddMove(row, col, currentPlayer == 'X' ? PlayerEnum.X : PlayerEnum.O, true);
                return true;
            }
            return false;
        }

        // Check for a game draw.
        private bool CheckForDraw()
        {
            return turns >= 9;
        }

        private bool CheckForWin()
        {
            return (CheckRows() || CheckColumns() || CheckDiagonals());
        }
        // check for a row win by completing it.
        private bool CheckRows()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }
        // check for a column win by completing it.
        private bool CheckColumns()
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }
        // check for a diagonal win by completing it.
        private bool CheckDiagonals()
        {
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            {
                return true;
            }
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            {
                return true;
            }
            return false;
        }
        //Switch to the other player
        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }


}
