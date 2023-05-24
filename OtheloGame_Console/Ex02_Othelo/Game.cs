using System;
using System.Collections.Generic;

namespace Ex02_Othelo
{
    internal class Game
    {
        private Board m_board;
        private Player m_player1;
        private Player m_player2;
        private Player m_currPlayer;

        public Game(Board i_board, Player i_player1, Player i_player2)
        {
            this.m_board = i_board;
            this.m_player1 = i_player1;
            this.m_player2 = i_player2;
            this.m_currPlayer = i_player1;
        }

        public Board Board
        {
            get { return this.m_board; }
        }

        public Player CurrPlayer
        {
            get { return this.m_currPlayer; }
        }

        public Player Player1
        {
            get { return this.m_player1; }
        }

        public Player Player2
        {
            get { return this.m_player2; }
        }

        public void SwitchPlayer()
        {
            if(m_currPlayer.Color == Player.eColor.White)
            {
                m_currPlayer = this.m_player2;
            }
            else
            {
                m_currPlayer = this.m_player1;
            }
        }

        public bool AreThereAvailableMoves()
        {
            bool availableMoveFound = false;
            for (int i = 0; i < m_board.BoardSize; i++)
            {
                for(int j = 0; j < m_board.BoardSize; j++)
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

        private List<int[]> getAvailableMoves()
        {
            List<int[]> availableMoves = new List<int[]>();
            for (int i = 0; i < m_board.BoardSize; i++)
            {
                for (int j = 0; j < m_board.BoardSize; j++)
                {
                    if (TryToMakeMove(i, j, false))
                    {
                        availableMoves.Add(new int[] { i, j });
                    }
                }
            }

            return availableMoves;
        }

        public bool TryToMakeMove(int i_row, int i_col, bool i_makeMove)
        {
            bool availableMovesExists = false;
            if (this.Board.GetCellVal(i_row, i_col) == ' ')
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
                            if (this.m_board.IsCellInRange(i_row + i, i_col + j))
                            {
                                if ((char)m_currPlayer.Color != this.m_board.GetCellVal(i_row + i, i_col + j) && this.m_board.GetCellVal(i_row + i, i_col + j) != ' ')
                                {
                                    if (availableMovesExists == false)
                                    {
                                        availableMovesExists = isValidMove(i_row + i, i_col + j, i, j, i_makeMove);
                                    }
                                    else
                                    {
                                        isValidMove(i_row + i, i_col + j, i, j, i_makeMove);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return availableMovesExists;
        }

        private bool isValidMove(int i_row, int i_col, int i_rowDirection, int i_colDirection, bool i_makeMove)
        {
            bool availableMove = false;
            char color = this.m_board.GetCellVal(i_row, i_col);
            while(this.m_board.IsCellInRange(i_row + i_rowDirection, i_col + i_colDirection))
            {
                i_row += i_rowDirection;
                i_col += i_colDirection;
                if (color != this.m_board.GetCellVal(i_row, i_col) && this.m_board.GetCellVal(i_row, i_col) != ' ')
                {
                    availableMove = true;
                    if(i_makeMove)
                    {
                        makeMove(i_row, i_col, i_rowDirection, i_colDirection);
                    }

                    break;
                }

                if (this.m_board.GetCellVal(i_row, i_col) == ' ')
                {
                    break;
                }
            }

            return availableMove;
        }

        private void makeMove(int i_row, int i_col, int i_rowDirection, int i_colDirection)
        {
            char playerColor = this.m_board.GetCellVal(i_row, i_col);
            while (this.m_board.GetCellVal(i_row - i_rowDirection, i_col - i_colDirection) != ' ' && this.m_board.GetCellVal(i_row - i_rowDirection, i_col - i_colDirection) != playerColor)
            {
                this.m_board.SetCellVal(i_row - i_rowDirection, i_col - i_colDirection, playerColor);
                i_row -= i_rowDirection;
                i_col -= i_colDirection;
            }

            this.m_board.SetCellVal(i_row - i_rowDirection, i_col - i_colDirection, playerColor);
        }

        public void CalculatePlayersScore()
        {
            for(int i = 0; i < this.Board.BoardSize; i++)
            {
                for(int j = 0; j < this.Board.BoardSize; j++)
                {
                    if(this.Board.GetCellVal(i, j) == (char)this.m_player1.Color)
                    {
                        this.m_player1.IncreaseScore();
                    }

                    if (this.Board.GetCellVal(i, j) == (char)this.m_player2.Color)
                    {
                        this.m_player2.IncreaseScore();
                    }
                }
            }
        }

        public void MakeComputerMove()
        {
            Random rand = new Random();
            List<int[]> availableMoves = getAvailableMoves();
            int randCell = rand.Next(0, availableMoves.Count);
            TryToMakeMove(availableMoves[randCell][0], availableMoves[randCell][1], true);
        }
    }
}
