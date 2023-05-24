namespace Ex05_WinFormsOthello
{
    internal class Square : System.Windows.Forms.PictureBox
    {
        public const int k_Size = 40;
        private Coin m_Coin = null;

        public Square()
        {
            Enabled = false;
            Size = new System.Drawing.Size(k_Size, k_Size);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;

            if(m_Coin != null)
            {
                isEmpty = false;
            }

            return isEmpty;
        }

        public Coin Coin
        {
            get { return m_Coin; }
            set 
            { 
                m_Coin = value;
                Image = m_Coin.Image;
            }
        }

        public void SetAsAvailableMove()
        {
            Enabled = true;
            BackColor = System.Drawing.Color.LightGreen;
        }

        public void SetAsUnvailableMove()
        {
            Enabled = false;
            BackColor = System.Drawing.Color.Transparent;
        }
    }
}