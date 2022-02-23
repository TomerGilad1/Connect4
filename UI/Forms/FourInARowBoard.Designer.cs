using System.Windows.Forms;

namespace UI
{
    public partial class FourInARowBoard : Form
    {
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent(int o_Cols, int o_Rows,int o_Width,int o_Height)
        {
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = false;
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.player1Label.Dock = DockStyle.Left;
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = false;
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.player2Label.Dock = DockStyle.Left;
            updateScore();
            // 
            // FourInARowBoard
            // 
            this.Name = "FourInARow";
            this.Text = "Four In A Row";
            generateColumnsButtons(o_Cols);
            generateMatrixButtons(o_Rows, o_Cols);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.player2Label);
            this.MinimumSize = new System.Drawing.Size(o_Width, o_Height);
            this.MaximumSize = new System.Drawing.Size(o_Width, o_Height);
            this.ResumeLayout(false);
        }

        private void generateColumnsButtons(int i_Cols)
        {
            m_ColumnsButtons = new Button[i_Cols];
            Button currentButton;

            for (int i = 0; i < i_Cols; i++)
            {
                currentButton = createNewColumButton(i);
                m_ColumnsButtons[i] = currentButton;
            }
        }

        private void generateMatrixButtons(int i_Rows, int i_Cols)
        {
            m_ButtonMatrix = new Button[i_Rows, i_Cols];

            for (int i = 0; i < i_Cols; i++)
            {
                for (int j = 0; j < i_Rows; j++)
                {
                    m_ButtonMatrix[j, i] = new Button();
                    m_ButtonMatrix[j, i].Parent = this;
                    m_ButtonMatrix[j, i].Visible = true;
                    m_ButtonMatrix[j, i].Location = new System.Drawing.Point(i * 45 + 15, j * 45 + 45);
                    m_ButtonMatrix[j, i].Name = "Button";
                    m_ButtonMatrix[j, i].Size = new System.Drawing.Size(40, 40);
                    m_ButtonMatrix[j, i].Text = string.Empty;
                    m_ButtonMatrix[j, i].ForeColor = System.Drawing.Color.Black;
                    m_ButtonMatrix[j, i].TabIndex = 0;
                    m_ButtonMatrix[j, i].UseCompatibleTextRendering = true;
                    m_ButtonMatrix[j, i].Tag = i * j + j;
                    m_ButtonMatrix[j, i].TabStop = false;
                }
            }
        }

        private Button createNewColumButton(int i_ButtonNumber)
        {
            Button button = new Button();
            int buttonText = i_ButtonNumber+1;

            button.Location = new System.Drawing.Point(i_ButtonNumber * 45 + 15, 20);
            button.Text = buttonText.ToString();
            button.Name = "button";
            button.Size = new System.Drawing.Size(40, 20);
            button.TabIndex = i_ButtonNumber;
            button.UseVisualStyleBackColor = true;
            button.Tag = i_ButtonNumber;
            button.TabStop = false;
            button.Click += new System.EventHandler(this.buttons_Click);
            this.Controls.Add(button);

            return button;
        }

        #endregion
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
    }
}