namespace Ex05_WinFormsOthello
{
    internal class Coin
    {
        private readonly Player.eColor r_Color;
        private readonly System.Drawing.Image r_Image;

        public Coin(Player.eColor i_Color)
        {
            r_Color = i_Color;

            if(i_Color == Player.eColor.Yellow)
            {
                r_Image = Properties.Resources.CoinYellow;
            }
            else
            {
                r_Image = Properties.Resources.CoinRed;
            }
        }

        public Player.eColor Color
        {
            get { return r_Color; }
        }

        public System.Drawing.Image Image
        {
            get { return r_Image; }
        }
    }
}