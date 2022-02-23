using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Logic;

namespace UI
{
    public partial class FourInARowBoard : Form
    {
        private readonly FourInARowGame r_Game;
        private int m_CurrentPlayer;
        private Button[,] m_ButtonMatrix;
        private Button[] m_ColumnsButtons;

        public FourInARowBoard(FourInARowGame i_Game)
        {
            int width = 0, heigh = 0;
            int rows = 0, cols = 0;

            r_Game = i_Game;
            rows = i_Game.Board.ENumBoard.GetLength(0);
            cols = i_Game.Board.ENumBoard.GetLength(1);
            m_CurrentPlayer = 0;
            m_ButtonMatrix = new Button[rows, cols];
            m_ColumnsButtons = new Button[cols];
            width = (cols * 45) + 30;
            heigh = (rows * 45) + 110;
            InitializeComponent(cols, rows, width, heigh);
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Logic.Point point;

            point = humanPlayerMove(sender);
            if (Logic.Logic.CheckIfWon(r_Game.Players[m_CurrentPlayer].Sign, ref point, r_Game.Board))
            {
                winningForm();
            }
            else
            {
                m_CurrentPlayer++;
                m_CurrentPlayer %= 2;
                if (r_Game.Player2.PlayerType == ePlayerType.Computer)
                {
                    point = makeAIMove();
                    if (Logic.Logic.CheckIfWon(r_Game.Players[m_CurrentPlayer].Sign, ref point, r_Game.Board))
                    {
                        winningForm();
                    }
                    else
                    {
                        m_CurrentPlayer++;
                        m_CurrentPlayer %= 2;
                    }
                }
            }

            if (r_Game.Board.AreAllColsFull())
            {
                tieForm();
            }
        }

        private void updateScore()
        {
            this.player1Label.Text = $"{r_Game.Player1.PlayerName} : {r_Game.Player1.Points}";
            this.player2Label.Text = $"{r_Game.Player2.PlayerName} : {r_Game.Player2.Points}";
        }

        private void winningForm()
        {
            eBoardSigns playerWonSign = playerWonSign = r_Game.Players[m_CurrentPlayer].Sign;
            DialogResult result;

            string msg = $"{r_Game.Players[m_CurrentPlayer].PlayerName} Won!!{Environment.NewLine}Another Round?";
            string caption = "A Win!";
            result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                r_Game.Players[m_CurrentPlayer].AddPoints(1);
                updateScore();
                ClearBoard();
                m_CurrentPlayer = 0;
            }
            else
            {
                Application.Exit();
            }
        }

        private void tieForm()
        {
            string msg = $"Tie!!{Environment.NewLine}Another Round?";
            string caption = "A Tie!";
            DialogResult result = MessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ClearBoard();
                m_CurrentPlayer = 0;
            }
            else
            {
                Application.Exit();
            }
        }

        public void ClearBoard()
        {
            r_Game.Board.InitialBoard();
            foreach (Button button in m_ColumnsButtons)
            {
                button.Enabled = true;
                button.BackColor = Control.DefaultBackColor;
            }

            foreach (Button button in m_ButtonMatrix)
            {
                button.Text = string.Empty;
                button.BackColor = Control.DefaultBackColor;
            }
        }

        private Logic.Point humanPlayerMove(object sender)
        {
            Button currentButton = sender as Button;
            int column = currentButton.TabIndex;
            Logic.Point point = new Logic.Point(column, 0);

            Logic.Logic.PushDown(ref point, r_Game.Board);
            r_Game.Board.SetMoveOnBoard(r_Game.Players[m_CurrentPlayer].Sign, ref point);
            m_ButtonMatrix[point.Y, point.X].Text = r_Game.Players[m_CurrentPlayer].Sign.ToString();
            if (r_Game.Board.ENumBoard[0, column] != eBoardSigns.Blank)
            {
                currentButton.Enabled = false;
            }

            return point;
        }

        private Logic.Point makeAIMove()
        {
            Logic.Point point = new Logic.Point();

            point = Logic.Logic.AIGenerateMinMaxAIMove(r_Game.Board, r_Game.AiLevel);
            r_Game.Board.SetMoveOnBoard(r_Game.Player2.Sign, ref point);
            m_ButtonMatrix[point.Y, point.X].Text = r_Game.Player2.Sign.ToString();
            if (r_Game.Board.ENumBoard[0, point.X] != eBoardSigns.Blank)
            {
                m_ColumnsButtons[point.X].Enabled = false;
            }

            return point;
        }
    }
}