using System;
using Ex02.ConsoleUtils;

namespace Ex02_Othelo
{
    internal class UI
    {
        private Game m_game;

        public UI()
        {
            short boardSize;
            int numOfPlayers;
            Player player1;
            Player player2;
            Console.Write("Please enter player name: ");
            player1 = new Player(Player.eColor.White, Console.ReadLine());
            Console.Write("Do you want to play with other player?\nenter '2' for yes, '1' for no: ");
            int.TryParse(Console.ReadLine(), out numOfPlayers);
            while (numOfPlayers != 1 && numOfPlayers != 2)
            {
                Console.Write("Invalid input, please try again: ");
                int.TryParse(Console.ReadLine(), out numOfPlayers);
            }

            if (numOfPlayers == 2)
            {
                Console.Write("Please enter second player name: ");
                player2 = new Player(Player.eColor.Black, Console.ReadLine());
            }
            else
            {
                player2 = new Player(Player.eColor.Black, "Computer", true);
            }

            Console.Write("Please enter board size, for 6X6 enter '6', for 8X8 enter '8': ");
            short.TryParse(Console.ReadLine(), out boardSize);
            while (boardSize != 6 && boardSize != 8)
            {
                Console.WriteLine("Invalid input, please try again:");
                short.TryParse(Console.ReadLine(), out boardSize);
            }

            this.m_game = new Game(new Board(boardSize), player1, player2);
        }

        public void RunGame()
        {
            bool gameEnded = false;
            bool isUserMoveAvailable = false;
            bool noAvailableMovesFlag = false;
            bool startNewGame = true;
            string newGameAnswer;
            string lastPlayerName = string.Empty;
            int row;
            int col;

            while (startNewGame)
            {
                while (gameEnded == false)
                {
                    if (this.m_game.AreThereAvailableMoves())
                    {
                        isUserMoveAvailable = false;
                        printBoard(this.m_game.Board);
                        if(noAvailableMovesFlag)
                        {
                            Console.WriteLine(string.Format("{0} had no available moves.", lastPlayerName));
                            noAvailableMovesFlag = false;
                        }

                        if (this.m_game.CurrPlayer.IsComputer)
                        {
                            Console.Write("The computer is making his move... ");
                            m_game.MakeComputerMove();
                            System.Threading.Thread.Sleep(1500);
                            this.m_game.SwitchPlayer();
                        }
                        else
                        {
                            Console.Write(string.Format("{0}, please make your move: ", this.m_game.CurrPlayer.PlayerName));
                            while (isUserMoveAvailable == false)
                            {
                                if (inputValidation(Console.ReadLine(), out row, out col))
                                {
                                    if (this.m_game.Board.IsCellInRange(row, col))
                                    {
                                        if (this.m_game.Board.GetCellVal(row, col) == ' ')
                                        {
                                            isUserMoveAvailable = this.m_game.TryToMakeMove(row, col, true);

                                            if (isUserMoveAvailable)
                                            {
                                                this.m_game.SwitchPlayer();
                                            }
                                            else
                                            {
                                                Console.Write("Unavailable move, please try again: ");
                                            }
                                        }
                                        else
                                        {
                                            Console.Write("Cell is already populated, please try again: ");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Out of the board range, please try again: ");
                                    }
                                }
                                else
                                {
                                    Console.Write("Invalid input, please try again: ");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (noAvailableMovesFlag)
                        {
                            gameEnded = true;
                            noAvailableMovesFlag = false;
                        }
                        else
                        {
                            noAvailableMovesFlag = true;
                            lastPlayerName = this.m_game.CurrPlayer.PlayerName;
                        }

                        this.m_game.SwitchPlayer();
                    }

                    Screen.Clear();
                }

                this.m_game.CalculatePlayersScore();
                Console.WriteLine(string.Format("{0}'s score is: {1}\n{2}'s score is: {3}", this.m_game.Player1.PlayerName, this.m_game.Player1.Score, this.m_game.Player2.PlayerName, this.m_game.Player2.Score));
                Console.Write("Would you like to play another game?\nfor yes enter '1', for no enter '0': ");
                newGameAnswer = Console.ReadLine();
                while(newGameAnswer.Length != 1 || char.IsDigit(newGameAnswer[0]) == false || (newGameAnswer[0] - 48 != 0 && newGameAnswer[0] - 48 != 1))
                {
                    Console.Write("Invalid input, please try again:");
                    newGameAnswer = Console.ReadLine();
                }

                Screen.Clear();
                if (newGameAnswer[0] - 48 == 0)
                {
                    startNewGame = false;
                    Console.WriteLine("Game over\nPress enter to exit.");
                }

                this.m_game.Board.InitializeBoard();
                this.m_game.Player1.InitializeScore();
                this.m_game.Player2.InitializeScore();
                gameEnded = false; 
            }
        }

        private bool inputValidation(string i_input, out int o_row, out int o_col)
        {
            bool isInputValid = false;
            o_row = -1;
            o_col = -1;
            if (i_input.Length == 2 && char.IsUpper(i_input[0]) && char.IsDigit(i_input[1]))
            {
                o_row = i_input[1] - 49;
                o_col = i_input[0] - 65;
                isInputValid = true;
            }

            if (i_input.Length == 1 && i_input[0] == 'Q')
            {
                Environment.Exit(0);
            }

            return isInputValid;
        }

        private void printBoard(Board i_board)
        {
            Screen.Clear();
            if (i_board.BoardSize == 8)
            {
                Console.WriteLine("       A   B   C   D   E   F   G   H");
            }
            else
            {
                Console.WriteLine("       A   B   C   D   E   F");
            }

            printBoundaryLine(i_board.BoardSize);
            for (int i = 0; i < i_board.BoardSize; i++)
            {
                Console.Write(string.Format("  {0}  ", i + 1));
                for (int j = 0; j < i_board.BoardSize; j++)
                {
                    Console.Write(printCell(i_board.GetCellVal(i, j)));
                }

                Console.WriteLine("|");
                printBoundaryLine(i_board.BoardSize);
            }
        }

        private string printCell(char i_charToCreate)
        {
            return string.Format("| {0} ", i_charToCreate.ToString());
        }

        private void printBoundaryLine(int i_boardSize)
        {
            if (i_boardSize == 8)
            {
                Console.WriteLine("     =================================");
            }
            else
            {
                Console.WriteLine("     =========================");
            }
        }
    }
}
