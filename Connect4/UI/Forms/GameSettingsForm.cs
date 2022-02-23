using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class GameSettingsForm : Form
    {
        private Logic.eAiDifficulty m_AiDifficulty;

        public GameSettingsForm()
        {
            InitializeComponent();
            m_AiDifficulty = Logic.eAiDifficulty.Easy;
            textBoxPlayer2.Enabled = false;
        }

        public Logic.eAiDifficulty AiDifficulty
        {
            get { return m_AiDifficulty; }
        }

        public string Player1
        {
            get { return textBoxPlayer1.Text; }
        }

        public string Player2
        {
            get { return textBoxPlayer2.Text; }
        }

        public bool IsPlayer2Computer
        {
            get { return !checkBoxPlayer2.Checked; }
        }

        public int Rows
        {
            get { return (int)numericUpDownRows.Value; }
        }

        public int Cols
        {
            get { return (int)numericUpDownCols.Value; }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.textBoxPlayer1.Text.Equals(string.Empty) || this.textBoxPlayer2.Text.Equals(string.Empty))
            {
                MessageBox.Show("Illegal player name input. Try again.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Minimum = 4;
            numericUpDownRows.Maximum = 10;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Minimum = 4;
            numericUpDownCols.Maximum = 10;
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (!textBoxPlayer2.Enabled)
            {
                textBoxPlayer2.Text = string.Empty;
                textBoxPlayer2.Enabled = true;
                radioButtonLevel1.Visible = false;
                radioButtonLevel2.Visible = false;
                radioButtonLevel3.Visible = false;
            }
            else
            {
                textBoxPlayer2.Text = "[Computer]";
                textBoxPlayer2.Enabled = false;
                radioButtonLevel1.Visible = true;
                radioButtonLevel2.Visible = true;
                radioButtonLevel3.Visible = true;
            }
        }

        private void radioButtonLevel1_CheckedChanged(object sender, EventArgs e)
        {
            m_AiDifficulty = Logic.eAiDifficulty.Easy;
        }

        private void radioButtonLevel2_CheckedChanged(object sender, EventArgs e)
        {
            m_AiDifficulty = Logic.eAiDifficulty.Medium;
        }

        private void radioButtonLevel3_CheckedChanged(object sender, EventArgs e)
        {
            m_AiDifficulty = Logic.eAiDifficulty.Hard;
        }
    }
}
