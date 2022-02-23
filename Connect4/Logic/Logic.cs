using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Logic
    {
        public static bool StopCheckForAFour(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            bool stopCheck = !i_Board.IsOnBoard(ref i_CurrentMove);
            eBoardSigns result;

            if (!stopCheck)
            {
                result = i_Board.ENumBoard[i_CurrentMove.Y, i_CurrentMove.X];
                if (!result.Equals(i_Sign))
                {
                    stopCheck = true;
                }
            }

            return stopCheck;
        }

        public static bool CheckIfWon(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            bool playerWon = false;
            bool fourInARow = CheckRow(i_Sign, ref i_CurrentMove, i_Board);
            bool fourInACol = CheckColumn(i_Sign, ref i_CurrentMove, i_Board);
            bool fourInADiagonal = CheckDiagonals(i_Sign, ref i_CurrentMove, i_Board);

            if (fourInARow || fourInACol || fourInADiagonal)
            {
                playerWon = true;
            }

            return playerWon;
        }

        public static bool CheckLeftDiagonal(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            int signCount = 1;
            bool stopCheckRightDown = false, stopCheckUpRLeft = false, diagonalFourInARow = false;
            Point currentPointToCheck = i_CurrentMove;

            while (!stopCheckRightDown)
            {
                currentPointToCheck.AddValues(1, 1);
                stopCheckRightDown = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckRightDown)
                {
                    signCount++;
                }
            }

            currentPointToCheck = i_CurrentMove;
            while (!stopCheckUpRLeft)
            {
                currentPointToCheck.AddValues(-1, -1);
                stopCheckUpRLeft = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckUpRLeft)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                diagonalFourInARow = true;
            }

            return diagonalFourInARow;
        }

        public static bool CheckRightDiagonal(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            int signCount = 1;
            bool stopCheckRightUp = false, stopCheckLeftDown = false, diagonalFourInARow = false;
            Point currentPointToCheck = i_CurrentMove;

            while (!stopCheckRightUp)
            {
                currentPointToCheck.AddValues(1, -1);
                stopCheckRightUp = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckRightUp)
                {
                    signCount++;
                }
            }

            currentPointToCheck = i_CurrentMove;
            while (!stopCheckLeftDown)
            {
                currentPointToCheck.AddValues(-1, 1);
                stopCheckLeftDown = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckLeftDown)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                diagonalFourInARow = true;
            }

            return diagonalFourInARow;
        }

        public static bool CheckDiagonals(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            bool playerWon = false;
            bool leftDiagonal = CheckLeftDiagonal(i_Sign, ref i_CurrentMove, i_Board);
            bool rightDiagonal = CheckRightDiagonal(i_Sign, ref i_CurrentMove, i_Board);

            if (leftDiagonal || rightDiagonal)
            {
                playerWon = true;
            }

            return playerWon;
        }

        public static bool CheckRow(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            bool fourInARow = false;
            bool stopCheckRight = false, stopCheckLeft = false;
            int signCount = 1;
            Point currentPointToCheck = i_CurrentMove;

            while (!stopCheckRight)
            {
                currentPointToCheck.AddXValue(1);
                stopCheckRight = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckRight)
                {
                    signCount++;
                }
            }

            currentPointToCheck = i_CurrentMove;
            while (!stopCheckLeft)
            {
                currentPointToCheck.AddXValue(-1);
                stopCheckLeft = StopCheckForAFour(i_Sign, ref currentPointToCheck, i_Board);
                if (!stopCheckLeft)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                fourInARow = true;
            }

            return fourInARow;
        }

        public static bool CheckColumn(eBoardSigns i_Sign, ref Point i_CurrentMove, Board i_Board)
        {
            bool stopCheckingDown = false;
            bool fourInACol = false;
            int signCount = 1;
            Point currentPosition = i_CurrentMove;

            while (!stopCheckingDown)
            {
                currentPosition.AddYValue(1);
                stopCheckingDown = StopCheckForAFour(i_Sign, ref currentPosition, i_Board);
                if (!stopCheckingDown)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                fourInACol = true;
            }

            return fourInACol;
        }

        public static bool CheckIfDraw(Board i_Board)
        {
            bool draw = i_Board.AreAllColsFull();

            return draw;
        }

        public static void PushDown(ref Point io_Point, Board i_Board)
        {
            bool stopPushingDown = false;
            bool newRowValid = false;
            bool newRowTaken = false;

            while (!stopPushingDown)
            {
                newRowValid = i_Board.ValidRow(io_Point.Y);
                if (newRowValid)
                {
                    newRowTaken = i_Board.IsTaken(ref io_Point);
                    if (!newRowTaken)
                    {
                        io_Point.AddYValue(1);
                    }
                    else
                    {
                        stopPushingDown = true;
                    }
                }
                else
                {
                    stopPushingDown = true;
                }
            }

            io_Point.AddYValue(-1);
        }

        public static Point AIGenerateMinMaxAIMove(Board io_Board, int io_AiLevel)
        {
            Point bestMove = new Point();
            Point currentMove;
            int score = 0;
            int bestScore = 100;
            int aiLevel = io_AiLevel * 2;

            for (int i = 0; i < io_Board.ENumBoard.GetLength(1); i++)
            {
                if (!io_Board.IsFullCol(i))
                {
                    currentMove = new Point(i, 0);
                    PushDown(ref currentMove, io_Board);
                    io_Board.SetMoveOnBoard(eBoardSigns.O, ref currentMove);
                    score = aiGenerateMinMaxAIMoveRec(aiLevel, io_Board, false, currentMove, eBoardSigns.X);
                    io_Board.SetMoveOnBoard(eBoardSigns.Blank, ref currentMove);
                    if (score < bestScore)
                    {
                        bestScore = score;
                        bestMove = currentMove;
                    }
                }
            }

            return bestMove;
        }

        private static int aiGenerateMinMaxAIMoveRec(int i_Depth, Board i_Board, bool io_MaximizingPlayer, Point i_CurrentMove, eBoardSigns i_CurrentPlayer)
        {
            int val = 0;
            int bestValue = 0;
            bool playerWon = false;
            eBoardSigns currentPlayer = eBoardSigns.Blank;
            Point currentMove = new Point();

            if (i_Depth <= 0)
            {
                return 0;
            }

            playerWon = CheckIfWon(i_CurrentPlayer, ref i_CurrentMove, i_Board);
            if (playerWon)
            {
                if (i_CurrentPlayer == eBoardSigns.O)
                {
                    return i_Depth;
                }
                else if (i_CurrentPlayer == eBoardSigns.X)
                {
                    return -i_Depth;
                }
            }
            else if (i_Board.AreAllColsFull())
            {
                return 0;
            }

            bestValue = io_MaximizingPlayer ? -1 : 1;
            for (int i = 0; i < i_Board.ENumBoard.GetLength(1); i++)
            {
                currentMove = new Point(i, 0);
                PushDown(ref currentMove, i_Board);
                if (!i_Board.IsFullCol(i))
                {
                    currentPlayer = io_MaximizingPlayer ? eBoardSigns.O : eBoardSigns.X;
                    i_Board.SetMoveOnBoard(currentPlayer, ref currentMove);
                    val = aiGenerateMinMaxAIMoveRec(i_Depth - 1, i_Board, !io_MaximizingPlayer, i_CurrentMove, currentPlayer);
                    bestValue = io_MaximizingPlayer ? Math.Max(bestValue, val) : Math.Min(bestValue, val);
                    i_Board.ClearCell(ref currentMove, eBoardSigns.Blank);
                }
            }

            return bestValue;
        }
    }
}