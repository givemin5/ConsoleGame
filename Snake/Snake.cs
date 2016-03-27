using System;
using System.Collections.Generic;
using CEngine;
using CGraphics;

namespace Snake
{
    /// <summary>  
    /// 贪吃蛇类  
    /// </summary>  
    internal class Snake
    {
        #region 字段  

        /// <summary>  
        /// 蛇身  
        /// </summary>  
        private List<CPoint> m_body;
        /// <summary>  
        /// 爬行方向  
        /// </summary>  
        private CDirection m_dir;
        /// <summary>  
        /// 蛇头  
        /// </summary>  
        private CPoint m_head;
        /// <summary>  
        /// 蛇尾  
        /// </summary>  
        private CPoint m_tail;

        #endregion

        #region 构造函数  

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="len"></param>  
        /// <param name="dir"></param>  
        public Snake(Int32 len, CDirection dir)
        {
            this.m_dir = dir;

            this.m_body = new List<CPoint>();

            for (Int32 i = 0; i <= len; i++)
            {
                m_body.Add(new CPoint(i + 1, 2));
            }

            if (m_body.Count > 0)
            {
                m_head = m_body[m_body.Count - 1];
                m_tail = m_body[0];
            }
        }

        #endregion

        #region 方法  

        /// <summary>  
        /// 设置方向  
        /// </summary>  
        /// <param name="dir"></param>  
        public void setDirection(CDirection dir)
        {
            this.m_dir = dir;
        }

        /// <summary>  
        /// 获取方向  
        /// </summary>  
        /// <returns></returns>  
        public CDirection getDirection()
        {
            return this.m_dir;
        }

        /// <summary>  
        /// 获取蛇头  
        /// </summary>  
        /// <returns></returns>  
        public CPoint getHead()
        {
            return m_body[m_body.Count - 1];
        }

        /// <summary>  
        /// 获取蛇尾  
        /// </summary>  
        /// <returns></returns>  
        private CPoint getTail()
        {
            return m_body[0];
        }

        /// <summary>  
        /// 添加蛇body节点  
        /// </summary>  
        /// <param name="point">新节点</param>  
        /// <param name="food">是否是食物节点</param>  
        public void addBodyNode(CPoint point, bool food)
        {
            //添加新节点  
            this.m_body.Add(point);
            //非食物节点则移除尾巴  
            if (!food)
            {
                if (this.m_body.Count > 0)
                {
                    this.m_body.Remove(getTail());
                }
            }
        }

        /// <summary>  
        /// 是否在某位置发生碰撞  
        /// </summary>  
        /// <param name="point"></param>  
        /// <returns></returns>  
        public Boolean isCollision(CPoint point)
        {
            Boolean flag = false;
            foreach (CPoint p in m_body)
            {
                flag = false;
                if (p == point)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>  
        /// 是否与自身发生碰撞  
        /// </summary>  
        /// <returns></returns>  
        public Boolean isSeftCollision()
        {
            Boolean flag = false;
            for (Int32 i = 0; i < m_body.Count - 1; i++)
            {
                flag = false;
                if (m_body[i] == getHead())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        /// <summary>  
        /// 蛇移动  
        /// </summary>  
        /// <returns></returns>  
        public bool move()
        {
            CPoint head = getHead();
            switch (m_dir)
            {
                case CDirection.Left:
                    if (head.getX() == 1)
                        return false;
                    head.setX(head.getX() - 1);
                    break;
                case CDirection.Right:
                    if (head.getX() == 28)
                        return false;
                    head.setX(head.getX() + 1);
                    break;
                case CDirection.Up:
                    if (head.getY() == 1)
                        return false;
                    head.setY(head.getY() - 1);
                    break;
                case CDirection.Down:
                    if (head.getY() == 23)
                        return false;
                    head.setY(head.getY() + 1);
                    break;
                default:
                    break;
            }
            addBodyNode(head, false);
            return true;
        }

        /// <summary>  
        /// 绘制蛇  
        /// </summary>  
        /// <param name="draw"></param>  
        public void draw(CDraw draw)
        {
            draw.setDrawSymbol(CSymbol.RING_SOLID);
            draw.fillRect(getHead().getX(), getHead().getY(), 1, 1, ConsoleColor.Yellow);
            draw.setDrawSymbol(CSymbol.DEFAULT);
            draw.fillRect(getTail().getX(), getTail().getY(), 1, 1, ConsoleColor.Black);
        }

        #endregion
    }
}