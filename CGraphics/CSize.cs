using System;

namespace CGraphics
{
    /// <summary>  
    /// 尺寸结构  
    /// </summary>  
    public struct CSize
    {
        private Int32 m_width;
        private Int32 m_height;

        public CSize(Int32 width, Int32 height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("尺寸大小不合法!");
            }
            this.m_width = width;
            this.m_height = height;
        }

        public Int32 getWidth()
        {
            return this.m_width;
        }

        public void setWidth(Int32 width)
        {
            this.m_width = width;
        }

        public Int32 getHeight()
        {
            return this.m_height;
        }

        public void setHeight(Int32 height)
        {
            this.m_height = height;
        }
    }
}