using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FourInARowGame
    {
        private readonly Player[] r_Players;
        private readonly Board r_Board;
        private int m_AiLevel = 0;

        public FourInARowGame(Board i_Board) 
        {
            r_Players = new Player[2];
            r_Board = i_Board;
        }

        public int AiLevel
        {
            get { return this.m_AiLevel; }
            set { this.m_AiLevel = value; }
        }

        public Board Board
        {
            get { return this.r_Board; }
        }

        public Player[] Players
        {
            get { return this.r_Players; }
        }

        public Player Player1
        {
            get { return this.r_Players[0]; }
            set { this.r_Players[0] = value; }
        }

        public Player Player2
        {
            get { return this.r_Players[1]; }
            set { this.r_Players[1] = value; }
        }
    }
}