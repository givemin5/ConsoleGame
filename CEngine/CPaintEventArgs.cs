using System;
using CGraphics;

namespace CEngine
{
    /// <summary>  
    /// 重绘事件参数  
    /// </summary>  
    public sealed class CPaintEventArgs : EventArgs
    {
        private CRect m_rect;
        private CDraw m_draw;

        public CPaintEventArgs(CRect rect, CDraw draw)
        {
            this.m_rect = rect;
            this.m_draw = draw;
        }

        public CRect getClientRect()
        {
            return this.m_rect;
        }

        public void setClientRect(CRect rect)
        {
            this.m_rect = rect;
        }

        public CDraw getDraw()
        {
            return this.m_draw;
        }

        public void setDraw(CDraw draw)
        {
            this.m_draw = draw;
        }
    }
}
