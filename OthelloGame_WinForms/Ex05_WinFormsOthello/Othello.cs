using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05_WinFormsOthello
{
    public partial class Othello : Form
    {
        private const int k_Padding = 30;
        private readonly GameSettings r_SettingsForm = new GameSettings();
        private Game m_Game = null;
        private List<int[]> m_AvailableMoves;

        public Othello()
        {
            InitializeComponent();
        }

        private void gameSettingsSelection()
        {
            if (r_SettingsForm.ShowDialog() == DialogResult.OK)
            {
                startNewGame(r_SettingsForm.BoardSize, r_SettingsForm.IsVsComputer);
            }
            else
            {
                Close();
            }
        }

        private void startNewGame(int i_BoardSize = 6, bool i_IsVsComputer = false)
        {
            if (m_Game == null)
            {
                m_Game = new Game(new Board(i_BoardSize), new Player(Player.eColor.Red, "Red"), new Player(Player.eColor.Yellow, "Yellow", i_IsVsComputer));
            }
            else
            {
                m_Game.Restart();
            }

            ClientSize = new Size((m_Game.Board.BoardSize * Square.k_Size) + (k_Padding * 2), (m_Game.Board.BoardSize * Square.k_Size) + (k_Padding * 2));
            CenterToScreen();
            for (int i = 0; i < m_Game.Board.BoardSize; i++)
            {
                for(int j = 0; j < m_Game.Board.BoardSize; j++)
                {
                    m_Game.Board.GetSquare(i, j).Click += new System.EventHandler(square_Click);
                    m_Game.Board.GetSquare(i, j).Location = new Point((i * Square.k_Size) + k_Padding, (j * Square.k_Size) + k_Padding);
                    Controls.Add(m_Game.Board.GetSquare(i, j));
                }
            }

            Text = string.Format("Othello - {0}'s Turn", m_Game.CurrPlayer.PlayerName);
            showAvailableMoves();
        }

        private void showAvailableMoves()
        {
            List<int[]> availableMovesIndexes = m_Game.GetAvailableMoves();
            foreach(int[] point in availableMovesIndexes)
            {
                m_Game.Board.GetSquare(point[0], point[1]).SetAsAvailableMove();
            }

            m_AvailableMoves = availableMovesIndexes;
        }

        private void square_Click(object sender, EventArgs e)
        {
            int squareRow = ((sender as Square).Location.X - k_Padding) / Square.k_Size;
            int squareCol = ((sender as Square).Location.Y - k_Padding) / Square.k_Size;
            m_Game.TryToMakeMove(squareRow, squareCol, true);
            switchPlayerAndCheckIfGameEnded();
            if (m_Game.CurrPlayer.IsComputer)
            {
                timerComputerTurn.Start();
            }
            else
            {
                showAvailableMoves();    
            }
        }

        private void switchPlayerAndCheckIfGameEnded()
        {
            cleanAvailableMoves(m_AvailableMoves);
            m_Game.SwitchPlayer();
            Text = string.Format("Othello - {0}'s Turn", m_Game.CurrPlayer.PlayerName);
            if (!m_Game.AreThereAvailableMoves())
            {
                m_Game.SwitchPlayer();
                if (!m_Game.AreThereAvailableMoves())
                {
                    timerComputerTurn.Stop();
                    Game.s_RoundsCount++;
                    m_Game.CalculatePlayersScore();
                    showWinnerMessage();
                }
                else
                {
                    Text = string.Format("Othello - {0}'s Turn", m_Game.CurrPlayer.PlayerName);
                }
            }
            else
            {
                if(!m_Game.CurrPlayer.IsComputer)
                {
                    showAvailableMoves();
                    timerComputerTurn.Stop();
                }
            }
        }

        private void showWinnerMessage()
        {
            string winnerMessage;
            if (m_Game.Player1.Score == m_Game.Player2.Score)
            {
                winnerMessage = string.Format("Draw!! ({0}/{1})\nWould you like another round?", m_Game.Player1.Score, m_Game.Player2.Score);
            }
            else
            {
                if (m_Game.Player1.Score > m_Game.Player2.Score)
                {
                    m_Game.Player1.WonRound();
                    winnerMessage = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})\nWould you like another round?", m_Game.Player1.PlayerName, m_Game.Player1.Score, m_Game.Player2.Score, m_Game.Player1.RoundsWon, Game.s_RoundsCount);
                }
                else
                {
                    m_Game.Player2.WonRound();
                    winnerMessage = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})\nWould you like another round?", m_Game.Player2.PlayerName, m_Game.Player2.Score, m_Game.Player1.Score, m_Game.Player2.RoundsWon, Game.s_RoundsCount);
                }
            }

            if (MessageBox.Show(winnerMessage, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Controls.Clear();
                startNewGame();
            }
            else
            {
                Close();
            }
        }

        private void cleanAvailableMoves(List<int[]> i_AvailableMovesIndexes)
        {
            foreach (int[] point in i_AvailableMovesIndexes)
            {
                m_Game.Board.GetSquare(point[0], point[1]).SetAsUnvailableMove();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            gameSettingsSelection();
        }

        private void timerComputerTurn_Tick(object sender, EventArgs e)
        {
            m_Game.MakeComputerMove();
            switchPlayerAndCheckIfGameEnded();
        }
    }
}