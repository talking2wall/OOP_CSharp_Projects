namespace Ex02_Othelo
{
    internal class Player
    {
        private readonly eColor r_color;
        private readonly bool r_isComputer;
        private string m_playerName;
        private int m_score = 0;

        public Player(eColor i_color, string i_playerName, bool i_isComputer = false)
        {
            this.PlayerName = i_playerName;
            this.r_color = i_color;
            this.r_isComputer = i_isComputer;
        }

        public enum eColor
        {
            Black = 'X',
            White = 'O'
        }

        public string PlayerName
        {
            get { return m_playerName; }
            set { m_playerName = value; }
        }

        public eColor Color
        {
            get { return r_color; }
        }

        public int Score
        {
            get { return this.m_score; }
        }

        public bool IsComputer
        {
            get { return this.r_isComputer; }
        }

        public void InitializeScore()
        {
            this.m_score = 0;
        }

        public void IncreaseScore()
        {
            this.m_score++;
        }
    }
}
