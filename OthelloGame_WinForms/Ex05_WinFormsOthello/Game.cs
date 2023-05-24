using System;
using System.Collections.Generic;

namespace Ex05_WinFormsOthello
{
    internal class Game
    {
        private readonly Board r_Board;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_CurrPlayer;
        public static int s_RoundsCount = 0;

        public Game(Board i_Board, Player i_Player1, Player i_Player2)
        {
            r_Board = i_Board;
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            m_CurrPlayer = i_Player1;
        }

        public Board Board
        {
            get { return r_Board; }
        }

        public Player CurrPlayer
        {
            get { return m_CurrPlayer; }
        }

        public Player Player1
        {
            get { return r_Player1; }
        }

        public Player Player2
        {
            get { return r_Player2; }
        }

        public void Restart()
        {
            Player1.InitializeScore();
            Player2.InitializeScore();
            Board.InitializeBoard();
            m_CurrPlayer = Player1;
        }

        public void SwitchPlayer()
        {
            if(m_CurrPlayer.Color == r_Player1.Color)
            {
                m_CurrPlayer = r_Player2;
            }
            else
            {
                m_CurrPlayer = r_Player1;
            }
        }

        public bool AreThereAvailableMoves()
        {
            bool availableMoveFound = false;
            for (int i = 0; i < r_Board.BoardSize; i++)
            {
                for(int j = 0; j < r_Board.BoardSize; j++)
                {
                    if(TryToMakeMove(i, j, false))
                    {
                        availableMoveFound = true;
                        break;
                    }
                }

                if (availableMoveFound)
                {
                    break;
                }
            }

            return availableMoveFound;
        }

        public List<int[]> GetAvailableMoves()
        {
            List<int[]> availableMoves = new List<int[]>();
            for (int i = 0; i < r_Board.BoardSize; i++)
            {
                for (int j = 0; j < r_Board.BoardSize; j++)
                {
                    if (TryToMakeMove(i, j, false))
                    {
                        availableMoves.Add(new int[] { i, j });
                    }
                }
            }

            return availableMoves;
        }

        public bool TryToMakeMove(int i_Row, int i_Col, bool i_MakeMove)
        {
            bool availableMovesExists = false;
            if (Board.GetSquare(i_Row, i_Col).IsEmpty())
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (r_Board.IsCellInRange(i_Row + i, i_Col + j))
                            {
                                if (!r_Board.GetSquare(i_Row + i, i_Col + j).IsEmpty() && m_CurrPlayer.Color != r_Board.GetSquareCoinColor(i_Row + i, i_Col + j))
                                {
                                    if (availableMovesExists == false)
                                    {
                                        availableMovesExists = isValidMove(i_Row + i, i_Col + j, i, j, i_MakeMove);
                                    }
                                    else
                                    {
                                        isValidMove(i_Row + i, i_Col + j, i, j, i_MakeMove);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return availableMovesExists;
        }

        private bool isValidMove(int i_Row, int i_Col, int i_RowDirection, int i_ColDirection, bool i_MakeMove)
        {
            bool availableMove = false;
            Player.eColor color = r_Board.GetSquareCoinColor(i_Row, i_Col);
            while(r_Board.IsCellInRange(i_Row + i_RowDirection, i_Col + i_ColDirection))
            {
                i_Row += i_RowDirection;
                i_Col += i_ColDirection;
                if (!r_Board.GetSquare(i_Row, i_Col).IsEmpty() && color != r_Board.GetSquareCoinColor(i_Row, i_Col))
                {
                    availableMove = true;
                    if(i_MakeMove)
                    {
                        makeMove(i_Row, i_Col, i_RowDirection, i_ColDirection);
                    }

                    break;
                }

                if (r_Board.GetSquare(i_Row, i_Col).IsEmpty())
                {
                    break;
                }
            }

            return availableMove;
        }

        private void makeMove(int i_Row, int i_Col, int i_RowDirection, int i_ColDirection)
        {
            Player.eColor playerColor = r_Board.GetSquareCoinColor(i_Row, i_Col);
            while (!r_Board.GetSquare(i_Row - i_RowDirection, i_Col - i_ColDirection).IsEmpty() && r_Board.GetSquareCoinColor(i_Row - i_RowDirection, i_Col - i_ColDirection) != playerColor)
            {
                r_Board.SetCoinToSquare(i_Row - i_RowDirection, i_Col - i_ColDirection, playerColor);
                i_Row -= i_RowDirection;
                i_Col -= i_ColDirection;
            }

            r_Board.SetCoinToSquare(i_Row - i_RowDirection, i_Col - i_ColDirection, playerColor);
        }

        public void CalculatePlayersScore()
        {
            for(int i = 0; i < Board.BoardSize; i++)
            {
                for(int j = 0; j < Board.BoardSize; j++)
                {
                    if (!Board.GetSquare(i, j).IsEmpty())
                    {
                        if (Board.GetSquareCoinColor(i, j) == r_Player1.Color)
                        {
                            r_Player1.IncreaseScore();
                        }

                        if (Board.GetSquareCoinColor(i, j) == r_Player2.Color)
                        {
                            r_Player2.IncreaseScore();
                        }
                    }
                }
            }
        }

        public void MakeComputerMove()
        {
            Random rand = new Random();
            List<int[]> availableMoves = GetAvailableMoves();
            int randCell = rand.Next(0, availableMoves.Count);
            TryToMakeMove(availableMoves[randCell][0], availableMoves[randCell][1], true);
        }
    }
}