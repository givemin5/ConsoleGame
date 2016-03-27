using System;
using System.Text;

namespace CGraphics
{
    /// <summary>  
    /// 绘图类  
    /// </summary>  
    public sealed class CDraw
    {
        /// <summary>  
        /// 绘制样式符号  
        /// </summary>  
        private CSymbol m_symbol;
        /// <summary>  
        /// 绘制背景颜色  
        /// </summary>  
        private ConsoleColor m_backcolor;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public CDraw()
        {
            this.m_symbol = CSymbol.RECT_EMPTY;
            this.m_backcolor = ConsoleColor.Black;
        }

        #region 绘制字符串  

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="rect">字符串绘制范围</param>  
        /// <param name="color">前景色</param>  
        public void drawText(String text, CRect rect, ConsoleColor color)
        {
            rect.adjustRect(ref rect);

            //不处理空字符串  
            if (text == "")
            {
                return;
            }
            //反色处理  
            Console.BackgroundColor = this.m_backcolor;
            Console.ForegroundColor = this.m_backcolor == color ? (ConsoleColor)(15 - (Int32)this.m_backcolor) : color;
            Console.SetCursorPosition(rect.getX(), rect.getY());

            //获取绘制范围字节数  
            Int32 charLen = rect.getWidth() * rect.getHeight() << 1;
            //字符串字节数  
            Int32 textLen = CText.getLength(text);

            //截断字符串适应绘制范围  
            text = CText.cutText(text, textLen > charLen ? charLen : textLen);

            //字符串换行  
            text = CText.lineBreakText(text, rect.getWidth());

            String[] texts = text.Split(Environment.NewLine.ToCharArray());

            Int32 i = 0;
            foreach (String s in texts)
            {
                if (s != "")
                {
                    Console.SetCursorPosition(rect.getX(), rect.getY() + i);
                    Console.Write(s);
                    i++;
                }
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="width">绘制范围宽度</param>  
        /// <param name="height">绘制范围高度</param>  
        /// <param name="color">颜色</param>  
        public void drawText(String text, Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)
        {
            drawText(text, new CRect(x, y, width, height), color);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="point">位置</param>  
        /// <param name="width">绘制范围宽度</param>  
        /// <param name="height">绘制范围高度</param>  
        /// <param name="color">颜色</param>  
        public void drawText(String text, CPoint point, Int32 width, Int32 height, ConsoleColor color)
        {
            drawText(text, new CRect(point, width, height), color);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">绘制范围尺寸</param>  
        /// <param name="color">颜色</param>  
        public void drawText(String text, Int32 x, Int32 y, CSize size, ConsoleColor color)
        {
            drawText(text, new CRect(x, y, size), color);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void drawText(String text, CPoint point, CSize size, ConsoleColor color)
        {
            drawText(text, new CRect(point, size), color);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="x">光标列位置</param>  
        /// <param name="y">光标行位置</param>  
        /// <param name="color">前景色</param>  
        public void drawText(String text, Int32 x, Int32 y, ConsoleColor color)
        {
            //不处理空字符串  
            if (text == "")
            {
                return;
            }
            //反色处理  
            Console.BackgroundColor = this.m_backcolor;
            Console.ForegroundColor = this.m_backcolor == color ? (ConsoleColor)(15 - (Int32)this.m_backcolor) : color;
            Console.SetCursorPosition(x >= Console.WindowWidth ? Console.WindowWidth - 1 : x, y);

            //绘制  
            Console.Write(text);

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 绘制字符串  
        /// </summary>  
        /// <param name="text"></param>  
        /// <param name="point"></param>  
        /// <param name="color"></param>  
        public void drawText(String text, CPoint point, ConsoleColor color)
        {
            drawText(text, point.getX(), point.getY(), color);
        }

        #endregion

        #region 绘制矩形  

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="rect">矩形</param>  
        /// <param name="color">前景色</param>  
        public void drawRect(CRect rect, ConsoleColor color)
        {
            //调整矩形  
            rect.adjustRect(ref rect);

            int x = rect.getX();
            int y = rect.getY();
            int width = rect.getWidth();
            int height = rect.getHeight();

            //根据符号设置颜色  
            if (m_symbol == CSymbol.DEFAULT)
            {
                Console.BackgroundColor = color;
            }
            else
            {
                Console.BackgroundColor = this.m_backcolor;
                //反色处理  
                Console.ForegroundColor = this.m_backcolor == color ? (ConsoleColor)(15 - (Int32)this.m_backcolor) : color;
            }

            //获取符号字符串  
            String charSymbol = CSymbolHelper.getStringFromSymbol(m_symbol);

            //绘制矩形列  
            for (Int32 i = 0; i < width; i++)
            {
                Int32 ix = x + (i << 1);
                if (ix >= Console.WindowWidth)
                    ix = Console.WindowWidth - 1;

                Console.SetCursorPosition(ix, y);
                Console.Write(charSymbol);
                Console.SetCursorPosition(ix, y + height - 1);
                Console.Write(charSymbol);
            }

            //绘制矩形行  
            for (Int32 i = 0; i < height; i++)
            {
                Int32 ix = x + (width << 1) - 2;
                if (ix >= Console.WindowWidth)
                    ix = Console.WindowWidth - 1;

                Console.SetCursorPosition(x, y + i);
                Console.Write(charSymbol);
                Console.SetCursorPosition(ix, y + i);
                Console.Write(charSymbol);
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="x">列</param>  
        /// <param name="y">行</param>  
        /// <param name="width">宽度</param>  
        /// <param name="height">高度</param>  
        /// <param name="color">颜色</param>  
        public void drawRect(Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)
        {
            drawRect(new CRect(x, y, width, height), color);
        }

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void drawRect(CPoint point, CSize size, ConsoleColor color)
        {
            drawRect(new CRect(point, size), color);
        }

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void drawRect(Int32 x, Int32 y, CSize size, ConsoleColor color)
        {
            drawRect(new CRect(x, y, size), color);
        }

        /// <summary>  
        /// 绘制矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="width">宽</param>  
        /// <param name="height">高</param>  
        /// <param name="color">颜色</param>  
        public void drawRect(CPoint point, Int32 width, Int32 height, ConsoleColor color)
        {
            drawRect(new CRect(point, width, height), color);
        }

        #endregion

        #region 填充矩形  

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="rect">矩形</param>  
        /// <param name="color">前景色</param>  
        public void fillRect(CRect rect, ConsoleColor color)
        {
            //调整矩形  
            rect.adjustRect(ref rect);

            int x = rect.getX();
            int y = rect.getY();
            int width = rect.getWidth();
            int height = rect.getHeight();

            //根据符号设置颜色  
            if (m_symbol == CSymbol.DEFAULT)
            {
                Console.BackgroundColor = color;
            }
            else
            {
                Console.BackgroundColor = this.m_backcolor;
                Console.ForegroundColor = this.m_backcolor == color ? (ConsoleColor)(15 - (Int32)this.m_backcolor) : color;
            }

            //获取符号字符串  
            String charSymbol = CSymbolHelper.getStringFromSymbol(m_symbol);

            StringBuilder strb = new StringBuilder();
            for (Int32 i = 0; i < width; i++)
            {
                strb.Append(charSymbol);
            }

            for (Int32 i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(strb.ToString());
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="x">列</param>  
        /// <param name="y">行</param>  
        /// <param name="width">宽度</param>  
        /// <param name="height">高度</param>  
        /// <param name="color">颜色</param>  
        public void fillRect(Int32 x, Int32 y, Int32 width, Int32 height, ConsoleColor color)
        {
            fillRect(new CRect(x, y, width, height), color);
        }

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void fillRect(CPoint point, CSize size, ConsoleColor color)
        {
            fillRect(new CRect(point, size), color);
        }

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="x">x</param>  
        /// <param name="y">y</param>  
        /// <param name="size">尺寸</param>  
        /// <param name="color">颜色</param>  
        public void fillRect(Int32 x, Int32 y, CSize size, ConsoleColor color)
        {
            fillRect(new CRect(x, y, size), color);
        }

        /// <summary>  
        /// 填充矩形  
        /// </summary>  
        /// <param name="point">位置</param>  
        /// <param name="width">宽</param>  
        /// <param name="height">高</param>  
        /// <param name="color">颜色</param>  
        public void fillRect(CPoint point, Int32 width, Int32 height, ConsoleColor color)
        {
            fillRect(new CRect(point, width, height), color);
        }

        #endregion

        /// <summary>  
        /// 用指定背景色清屏  
        /// </summary>  
        /// <param name="color"></param>  
        public void clear(ConsoleColor color)
        {
            this.m_symbol = CSymbol.DEFAULT;
            this.m_backcolor = color;
            fillRect(0, 0, Console.WindowWidth >> 1, Console.WindowHeight, color);
        }

        /// <summary>  
        /// 设置背景颜色  
        /// </summary>  
        /// <param name="color"></param>  
        public void setBackcolor(ConsoleColor color)
        {
            this.m_backcolor = color;
        }

        /// <summary>  
        /// 获取背景颜色  
        /// </summary>  
        /// <returns></returns>  
        public ConsoleColor getBackcolor()
        {
            return this.m_backcolor;
        }

        /// <summary>  
        /// 设置控制台绘制符号  
        /// </summary>  
        /// <param name="symbol"></param>  
        public void setDrawSymbol(CSymbol symbol)
        {
            this.m_symbol = symbol;
        }

        /// <summary>  
        /// 获取控制台绘制符号  
        /// </summary>  
        /// <returns></returns>  
        public CSymbol getDrawSymbol()
        {
            return this.m_symbol;
        }
    }
}
