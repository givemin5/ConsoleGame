using System;

namespace CGraphics
{
    /// <summary>  
    /// 矩形结构  
    /// </summary>  
    public struct CRect
    {
        /// <summary>  
        /// 左上角列坐标  
        /// </summary>  
        private Int32 m_x;
        /// <summary>  
        /// 左上角行坐标  
        /// </summary>  
        private Int32 m_y;
        /// <summary>  
        /// 矩形宽度  
        /// </summary>  
        private Int32 m_width;
        /// <summary>  
        /// 矩形高度  
        /// </summary>  
        private Int32 m_height;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="x"></param>  
        /// <param name="y"></param>  
        /// <param name="w"></param>  
        /// <param name="h"></param>  
        public CRect(Int32 x, Int32 y, Int32 w, Int32 h)
        {
            if (w <= 0 || h <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_x = x;
            this.m_y = y;
            this.m_width = w;
            this.m_height = h;
        }

        public CRect(CPoint point, Int32 w, Int32 h)
        {
            this.m_x = point.getX();
            this.m_y = point.getY();
            this.m_width = w;
            this.m_height = h;
        }

        public CRect(Int32 x, Int32 y, CSize size)
        {
            this.m_x = x;
            this.m_y = y;
            this.m_width = size.getWidth();
            this.m_height = size.getHeight();
        }

        public CRect(CPoint point, CSize size)
        {
            this.m_x = point.getX();
            this.m_y = point.getY();
            this.m_width = size.getWidth();
            this.m_height = size.getHeight();
        }

        /// <summary>  
        /// 获取左上角列坐标  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getX()
        {
            return this.m_x;
        }
        /// <summary>  
        /// 获取左上角行坐标  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getY()
        {
            return this.m_y;
        }
        /// <summary>  
        /// 获取矩形宽度  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getWidth()
        {
            return this.m_width;
        }
        /// <summary>  
        /// 获取矩形高度  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getHeight()
        {
            return this.m_height;
        }
        /// <summary>  
        /// 获取矩形  
        /// </summary>  
        /// <returns></returns>  
        public CRect getCRect()
        {
            return new CRect(this.m_x, this.m_y, this.m_width, this.m_height);
        }
        /// <summary>  
        /// 设置左上角列坐标  
        /// </summary>  
        /// <param name="x"></param>  
        public void setX(Int32 x)
        {
            this.m_x = x;
        }
        /// <summary>  
        /// 设置左上角行坐标  
        /// </summary>  
        /// <param name="y"></param>  
        public void setY(Int32 y)
        {
            this.m_y = y;
        }
        /// <summary>  
        /// 设置矩形宽度  
        /// </summary>  
        /// <param name="w"></param>  
        public void setWidth(Int32 w)
        {
            if (w <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_width = w;
        }
        /// <summary>  
        /// 设置矩形高度  
        /// </summary>  
        /// <param name="h"></param>  
        public void setHeight(Int32 h)
        {
            if (h <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_height = h;
        }
        /// <summary>  
        /// 设置矩形  
        /// </summary>  
        /// <param name="x"></param>  
        /// <param name="y"></param>  
        /// <param name="w"></param>  
        /// <param name="h"></param>  
        public void setCRect(Int32 x, Int32 y, Int32 w, Int32 h)
        {
            if (w <= 0 || h <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.m_x = x;
            this.m_y = y;
            this.m_width = w;
            this.m_height = h;
        }
        /// <summary>  
        /// 缩放  
        /// </summary>  
        /// <param name="flateX"></param>  
        /// <param name="flateY"></param>  
        public void inflate(Int32 flateX, Int32 flateY)
        {
            this.m_x -= flateX;
            this.m_y -= flateY;
            this.m_width += flateX << 1;
            this.m_height += flateY << 1;
        }

        /// <summary>  
        /// 调整矩形位置与尺寸  
        /// </summary>  
        /// <param name="rect"></param>  
        /// <returns></returns>  
        public void adjustRect(ref CRect rect)
        {
            Int32 maxX = Console.WindowWidth >> 1;
            Int32 maxY = Console.WindowHeight;

            if (rect.m_x < 0)
            {
                rect.m_x = 0;
            }
            else if (rect.m_x > maxX)
            {
                rect.m_x = maxX - 1;
            }

            if (rect.m_y < 0)
            {
                rect.m_y = 0;
            }
            else if (rect.m_y > maxY)
            {
                rect.m_y = maxY;
            }

            rect.m_x += rect.m_x;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3}]", m_x, m_y, m_width, m_height);
        }
    }
}