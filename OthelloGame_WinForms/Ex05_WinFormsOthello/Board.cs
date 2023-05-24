namespace Ex05_WinFormsOthello
{
    internal class Board
    {
        private readonly int r_BoardSize;
        private readonly Square[,] r_BoardMatrix;

        public Board(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            r_BoardMatrix = new Square[r_BoardSize, r_BoardSize];
            InitializeBoard();
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }

        public void SetCoinToSquare(int i_Row, int i_Col, Player.eColor i_Color)
        {
            r_BoardMatrix[i_Row, i_Col].Coin = new Coin(i_Color);
        }

        public Player.eColor GetSquareCoinColor(int i_Row, int i_Col)
        {
            return r_BoardMatrix[i_Row, i_Col].Coin.Color;
        }

        public Square GetSquare(int i_Row, int i_Col)
        {
            return r_BoardMatrix[i_Row, i_Col];
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < r_BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < r_BoardMatrix.GetLength(1); j++)
                {
                    r_BoardMatrix[i, j] = new Square();
                }
            }

            SetCoinToSquare((BoardSize / 2) - 1, (BoardSize / 2) - 1, Player.eColor.Yellow);
            SetCoinToSquare((BoardSize / 2) - 1, BoardSize / 2, Player.eColor.Red);
            SetCoinToSquare(BoardSize / 2, BoardSize / 2, Player.eColor.Yellow);
            SetCoinToSquare(BoardSize / 2, (r_BoardSize / 2) - 1, Player.eColor.Red);
        }

        public bool IsCellInRange(int i_Row, int i_Col)
        {
            bool isInRange = true;
            if (i_Row >= BoardSize || i_Row < 0 || i_Col >= BoardSize || i_Col < 0)
            {
                isInRange = false;
            }

            return isInRange;
        }
    }
}