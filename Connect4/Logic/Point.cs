using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public struct Point
    {
        private int m_X;
        private int m_Y;

        public Point(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        public void AddValues(int i_X, int i_Y)
        {
            m_X += i_X;
            m_Y += i_Y;
        }

        public void AddXValue(int i_X)
        {
            m_X += i_X;
        }

        public void AddYValue(int i_Y)
        {
            m_Y += i_Y;
        }
    }
}