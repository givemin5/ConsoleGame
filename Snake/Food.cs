using System;
using CEngine;
using CGraphics;

namespace Snake
{
    /// <summary>  
    /// 食物类  
    /// </summary>  
    internal class Food
    {
        /// <summary>  
        /// 位置  
        /// </summary>  
        private CPoint m_position;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public Food()
        {

        }

        public Food(CPoint point)
        {
            this.m_position = point;
        }

        /// <summary>  
        /// 获取位置  
        /// </summary>  
        /// <returns></returns>  
        public CPoint getPosition()
        {
            return this.m_position;
        }

        /// <summary>  
        /// 设置位置  
        /// </summary>  
        /// <param name="point"></param>  
        public void setPosition(CPoint point)
        {
            this.m_position = point;
        }

        /// <summary>  
        /// 设置位置  
        /// </summary>  
        /// <param name="x"></param>  
        /// <param name="y"></param>  
        public void setPosition(Int32 x, Int32 y)
        {
            this.m_position = new CPoint(x, y);
        }

        /// <summary>  
        /// 绘制食物  
        /// </summary>  
        /// <param name="draw"></param>  
        public void draw(CDraw draw)
        {
            draw.setDrawSymbol(CSymbol.RING_SOLID);
            draw.drawRect(m_position.getX(), m_position.getY(), 1, 1, ConsoleColor.Green);
        }
    }
}
