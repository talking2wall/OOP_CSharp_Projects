namespace Ex05_WinFormsOthello
{
    public partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSetBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayVsComputer = new System.Windows.Forms.Button();
            this.buttonPlayVsFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSetBoardSize
            // 
            this.buttonSetBoardSize.Location = new System.Drawing.Point(12, 24);
            this.buttonSetBoardSize.Name = "buttonSetBoardSize";
            this.buttonSetBoardSize.Size = new System.Drawing.Size(435, 40);
            this.buttonSetBoardSize.TabIndex = 0;
            this.buttonSetBoardSize.Text = "Board Size: 6x6 (click to increase)";
            this.buttonSetBoardSize.UseVisualStyleBackColor = true;
            this.buttonSetBoardSize.Click += new System.EventHandler(this.buttonSetBoardSize_Click);
            // 
            // buttonPlayVsComputer
            // 
            this.buttonPlayVsComputer.Location = new System.Drawing.Point(12, 83);
            this.buttonPlayVsComputer.Name = "buttonPlayVsComputer";
            this.buttonPlayVsComputer.Size = new System.Drawing.Size(205, 36);
            this.buttonPlayVsComputer.TabIndex = 1;
            this.buttonPlayVsComputer.Text = "Play against the computer";
            this.buttonPlayVsComputer.UseVisualStyleBackColor = true;
            this.buttonPlayVsComputer.Click += new System.EventHandler(this.buttonPlayVsComputer_Click);
            // 
            // buttonPlayVsFriend
            // 
            this.buttonPlayVsFriend.Location = new System.Drawing.Point(242, 83);
            this.buttonPlayVsFriend.Name = "buttonPlayVsFriend";
            this.buttonPlayVsFriend.Size = new System.Drawing.Size(205, 36);
            this.buttonPlayVsFriend.TabIndex = 2;
            this.buttonPlayVsFriend.Text = "Play against your friend";
            this.buttonPlayVsFriend.UseVisualStyleBackColor = true;
            this.buttonPlayVsFriend.Click += new System.EventHandler(this.buttonPlayVsFriend_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 148);
            this.Controls.Add(this.buttonPlayVsFriend);
            this.Controls.Add(this.buttonPlayVsComputer);
            this.Controls.Add(this.buttonSetBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSetBoardSize;
        private System.Windows.Forms.Button buttonPlayVsComputer;
        private System.Windows.Forms.Button buttonPlayVsFriend;
    }
}