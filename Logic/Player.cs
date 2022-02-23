using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Player
    {
        private readonly string r_PlayerName;
        private readonly eBoardSigns r_Sign;
        private readonly ePlayerType r_PlayerType;
        private int m_Points;

        public Player(eBoardSigns i_Sign, string i_PlayerName, ePlayerType i_PlayerType)
        {
            r_Sign = i_Sign;
            r_PlayerName = i_PlayerName;
            r_PlayerType = i_PlayerType;
            m_Points = 0;
        }

        public string PlayerName
        {
            get { return r_PlayerName; }
        }

        public ePlayerType PlayerType
        {
            get { return r_PlayerType; }
        }

        public int Points
        {
            get { return m_Points; }
        }

        public eBoardSigns Sign
        {
            get { return r_Sign; }
        }

        public void AddPoints(int i_Value)
        {
            m_Points += i_Value;
        }
    }
}