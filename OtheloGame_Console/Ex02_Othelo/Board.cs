namespace Ex02_Othelo
{
    internal class Board
    {
        private readonly short r_boardSize;
        private char[,] m_boardMatrix;

        public Board(short i_boardSize)
        {
            this.r_boardSize = i_boardSize;
            this.m_boardMatrix = new char[r_boardSize, r_boardSize];
            InitializeBoard();
        }

        public short BoardSize
        {
            get { return this.r_boardSize; }
        }

        public void SetCellVal(int i_row, int i_col, char i_val)
        {
            m_boardMatrix[i_row, i_col] = i_val;
        }

        public char GetCellVal(int i_row, int i_col)
        {
            return m_boardMatrix[i_row, i_col];
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < m_boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_boardMatrix.GetLength(1); j++)
                {
                    m_boardMatrix[i, j] = ' ';
                }
            }

            this.SetCellVal((BoardSize / 2) - 1, (BoardSize / 2) - 1, (char)Player.eColor.White);
            this.SetCellVal((BoardSize / 2) - 1, BoardSize / 2, (char)Player.eColor.Black);
            this.SetCellVal(BoardSize / 2, BoardSize / 2, (char)Player.eColor.White);
            this.SetCellVal(BoardSize / 2, (r_boardSize / 2) - 1, (char)Player.eColor.Black);
        }

        public bool IsCellInRange(int i_row, int i_col)
        {
            bool isInRange = true;
            if (i_row >= this.BoardSize || i_row < 0 || i_col >= this.BoardSize || i_col < 0)
            {
                isInRange = false;
            }

            return isInRange;
        }
    }
}