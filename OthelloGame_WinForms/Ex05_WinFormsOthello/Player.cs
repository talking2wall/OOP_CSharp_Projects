namespace Ex05_WinFormsOthello
{
    internal class Player
    {
        private readonly eColor r_Color;
        private readonly bool r_IsComputer;
        private string m_PlayerName;
        private int m_Score = 0;
        private int m_RoundsWon = 0;

        public Player(eColor i_Color, string i_PlayerName, bool i_IsComputer = false)
        {
            PlayerName = i_PlayerName;
            r_Color = i_Color;
            r_IsComputer = i_IsComputer;
        }

        public enum eColor
        {
            Yellow,
            Red
        }

        public int RoundsWon
        {
            get { return m_RoundsWon; }
        }

        public void WonRound()
        {
            m_RoundsWon++;
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public eColor Color
        {
            get { return r_Color; }
        }

        public int Score
        {
            get { return m_Score; }
        }

        public bool IsComputer
        {
            get { return r_IsComputer; }
        }

        public void InitializeScore()
        {
            m_Score = 0;
        }

        public void IncreaseScore()
        {
            m_Score++;
        }
    }
}