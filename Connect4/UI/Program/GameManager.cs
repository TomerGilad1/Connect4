using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Logic;

namespace UI
{
    public class GameManager
    {
        public void Start()
        {
            RunGame();
        }

        public void RunGame()
        {
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            FourInARowGame game;

            gameSettingsForm.ShowDialog();
            if (gameSettingsForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                game = initialFourInARowGame(ref gameSettingsForm);
                FourInARowBoard board = new FourInARowBoard(game);
                board.ShowDialog();
            }
        }

        private FourInARowGame initialFourInARowGame(ref GameSettingsForm i_gameSettingsForm)
        {
            FourInARowGame game;
            Board gameBoard;
            string player1Name, player2Name;
            int numRows, numCols;
            eAiDifficulty difficulty = eAiDifficulty.Easy;
            ePlayerType player2Type;

            player1Name = i_gameSettingsForm.Player1;
            player2Name = i_gameSettingsForm.Player2;
            numRows = i_gameSettingsForm.Rows;
            numCols = i_gameSettingsForm.Cols;
            if (i_gameSettingsForm.IsPlayer2Computer)
            {
                difficulty = i_gameSettingsForm.AiDifficulty;
                player2Type = ePlayerType.Computer;
            }
            else
            {
                player2Type = ePlayerType.Human;
            }

            gameBoard = new Board(numRows, numCols);
            game = new FourInARowGame(gameBoard);
            game.Player1 = new Player(eBoardSigns.X, player1Name, ePlayerType.Human);
            game.Player2 = new Player(eBoardSigns.O, player2Name, player2Type);
            game.AiLevel = (int)difficulty;

            return game;
        }
    }
}