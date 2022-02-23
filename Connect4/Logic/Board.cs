using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        private readonly eBoardSigns[,] r_Board;

        public eBoardSigns[,] ENumBoard
        {
            get { return this.r_Board; }
        }

        public bool ValidCol(int i_Col)
        {
            bool validCol = false;

            if (i_Col >= 0 && (i_Col < this.r_Board.GetLength(1)))
            {
                validCol = true;
            }

            return validCol;
        }

        public bool ValidRow(int i_Row)
        {
            bool validRow = false;

            if (i_Row >= 0 && i_Row < this.r_Board.GetLength(0))
            {
                validRow = true;
            }

            return validRow;
        }

        public bool IsOnBoard(ref Point i_CurrentMove)
        {
            bool onBoard = false;
            bool isValidCol = ValidCol(i_CurrentMove.X);
            bool isValidRow = ValidRow(i_CurrentMove.Y);

            if (isValidCol && isValidRow)
            {
                onBoard = true;
            }

            return onBoard;
        }

        public void SetMoveOnBoard(eBoardSigns i_Sign, ref Point i_CurrentMove)
        {
            r_Board[i_CurrentMove.Y, i_CurrentMove.X] = i_Sign;
        }

        public Board(int io_Rows, int io_Cols)
        {
            if (io_Rows > 0 && io_Cols > 0)
            {
                r_Board = new eBoardSigns[io_Rows, io_Cols];
            }

            InitialBoard();
        }

        public void InitialBoard()
        {
            for (int i = 0; i < this.r_Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.r_Board.GetLength(1); j++)
                {
                    this.r_Board[i, j] = eBoardSigns.Blank;
                }
            }
        }

        public bool IsTaken(ref Point i_Point)
        {
            bool taken = true;
            int col = i_Point.X;
            int row = i_Point.Y;

            if (this.r_Board[row, col] == eBoardSigns.Blank)
            {
                taken = false;
            }

            return taken;
        }

        public void ClearCell(ref Point i_Position, eBoardSigns i_Sign)
        {
            int y = i_Position.Y;
            int x = i_Position.X;
            this.r_Board[y, x] = i_Sign;
        }

        public bool IsFullCol(int i_Col)
        {
            bool isFullCol = r_Board[0, i_Col] != eBoardSigns.Blank;

            return isFullCol;
        }

        public bool AreAllColsFull()
        {
            bool allColsAreFull = true;

            for (int i = 0; i < this.r_Board.GetLength(1); i++)
            {
                bool blankSign = !IsFullCol(i);

                if (blankSign)
                {
                    allColsAreFull = false;
                    break;
                }
            }

            return allColsAreFull;
        }
    }
}