using System;
using System.Windows.Forms;

namespace Ex05_WinFormsOthello
{
    public partial class GameSettings : Form
    {
        private int m_BoardSize = 6;
        private bool m_IsVsComputer = false;

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public bool IsVsComputer
        {
            get { return m_IsVsComputer; }
        }

        public GameSettings()
        {
            InitializeComponent();
        }

        private void buttonSetBoardSize_Click(object sender, EventArgs e)
        {
            if(m_BoardSize == 12)
            {
                m_BoardSize = 6;
            }
            else
            {
                m_BoardSize += 2;
            }

            (sender as Button).Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize);
        }

        private void buttonPlayVsComputer_Click(object sender, EventArgs e)
        {
            m_IsVsComputer = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonPlayVsFriend_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
