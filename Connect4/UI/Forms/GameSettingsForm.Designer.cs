using System.Windows.Forms;

namespace UI
{
    public partial class GameSettingsForm : Form
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

        private void InitializeComponent()
        {
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.radioButtonLevel1 = new System.Windows.Forms.RadioButton();
            this.radioButtonLevel2 = new System.Windows.Forms.RadioButton();
            this.radioButtonLevel3 = new System.Windows.Forms.RadioButton();
            this.BoardSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(9, 14);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(47, 15);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayer1.Location = new System.Drawing.Point(44, 44);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(51, 15);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(45, 205);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(38, 15);
            this.labelRows.TabIndex = 2;
            this.labelRows.Text = "Rows:";
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(133, 205);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(33, 15);
            this.labelCols.TabIndex = 3;
            this.labelCols.Text = "Cols:";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(89, 203);
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(38, 23);
            this.numericUpDownRows.TabIndex = 4;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(172, 203);
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(38, 23);
            this.numericUpDownCols.TabIndex = 5;
            this.numericUpDownCols.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(121, 36);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(100, 23);
            this.textBoxPlayer1.TabIndex = 6;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(25, 79);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(70, 19);
            this.checkBoxPlayer2.TabIndex = 8;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(40, 249);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(181, 24);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.startButton_Click);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Location = new System.Drawing.Point(121, 75);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(100, 23);
            this.textBoxPlayer2.TabIndex = 11;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // radioButtonLevel1
            // 
            this.radioButtonLevel1.AutoSize = true;
            this.radioButtonLevel1.Checked = true;
            this.radioButtonLevel1.Location = new System.Drawing.Point(121, 104);
            this.radioButtonLevel1.Name = "radioButtonLevel1";
            this.radioButtonLevel1.Size = new System.Drawing.Size(62, 19);
            this.radioButtonLevel1.TabIndex = 12;
            this.radioButtonLevel1.TabStop = true;
            this.radioButtonLevel1.Text = "Easy AI";
            this.radioButtonLevel1.UseVisualStyleBackColor = true;
            this.radioButtonLevel1.CheckedChanged += new System.EventHandler(this.radioButtonLevel1_CheckedChanged);
            // 
            // radioButtonLevel2
            // 
            this.radioButtonLevel2.AutoSize = true;
            this.radioButtonLevel2.Location = new System.Drawing.Point(121, 129);
            this.radioButtonLevel2.Name = "radioButtonLevel2";
            this.radioButtonLevel2.Size = new System.Drawing.Size(84, 19);
            this.radioButtonLevel2.TabIndex = 13;
            this.radioButtonLevel2.Text = "Medium AI";
            this.radioButtonLevel2.UseVisualStyleBackColor = true;
            this.radioButtonLevel2.CheckedChanged += new System.EventHandler(this.radioButtonLevel2_CheckedChanged);
            // 
            // radioButtonLevel3
            // 
            this.radioButtonLevel3.AutoSize = true;
            this.radioButtonLevel3.Location = new System.Drawing.Point(121, 154);
            this.radioButtonLevel3.Name = "radioButtonLevel3";
            this.radioButtonLevel3.Size = new System.Drawing.Size(65, 19);
            this.radioButtonLevel3.TabIndex = 14;
            this.radioButtonLevel3.Text = "Hard AI";
            this.radioButtonLevel3.UseVisualStyleBackColor = true;
            this.radioButtonLevel3.CheckedChanged += new System.EventHandler(this.radioButtonLevel3_CheckedChanged);
            // 
            // BoardSizeLabel
            // 
            this.BoardSizeLabel.AutoSize = true;
            this.BoardSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BoardSizeLabel.Location = new System.Drawing.Point(34, 173);
            this.BoardSizeLabel.Name = "BoardSizeLabel";
            this.BoardSizeLabel.Size = new System.Drawing.Size(61, 15);
            this.BoardSizeLabel.TabIndex = 15;
            this.BoardSizeLabel.Text = "BoardSize:";
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 297);
            this.Controls.Add(this.BoardSizeLabel);
            this.Controls.Add(this.radioButtonLevel3);
            this.Controls.Add(this.radioButtonLevel2);
            this.Controls.Add(this.radioButtonLevel1);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Name = "GameSettingsForm";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.RadioButton radioButtonLevel1;
        private System.Windows.Forms.RadioButton radioButtonLevel2;
        private System.Windows.Forms.RadioButton radioButtonLevel3;
        private Label BoardSizeLabel;
    }
}