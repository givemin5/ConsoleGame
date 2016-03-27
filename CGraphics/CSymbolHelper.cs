using System;
using System.Text;

namespace CGraphics
{
    /// <summary>  
    /// 符号表 每个符号2字节  
    /// </summary>  
    public enum CSymbol
    {
        /// <summary>  
        /// 缺省符号  
        /// </summary>  
        DEFAULT = (UInt16)0xA1A1,
        /// <summary>  
        /// @@  
        /// </summary>  
        AT = (UInt16)0x4040,
        /// <summary>  
        /// ##  
        /// </summary>  
        WELL = (UInt16)0x2323,
        /// <summary>  
        /// ※  
        /// </summary>  
        RICE = (UInt16)0xA1F9,
        /// <summary>  
        /// ☆  
        /// </summary>  
        STAR_EMPTY = (UInt16)0xA1EE,
        /// <summary>  
        /// ★  
        /// </summary>  
        STAR_SOLID = (UInt16)0xA1EF,
        /// <summary>  
        /// ○  
        /// </summary>  
        RING_EMPTY = (UInt16)0xA1F0,
        /// <summary>  
        /// ●  
        /// </summary>  
        RING_SOLID = (UInt16)0xA1F1,
        /// <summary>  
        /// ◇  
        /// </summary>  
        RHOMB_EMPTY = (UInt16)0xA1F3,
        /// <summary>  
        /// ◆  
        /// </summary>  
        RHOMB_SOLID = (UInt16)0xA1F4,
        /// <summary>  
        /// □  
        /// </summary>  
        RECT_EMPTY = (UInt16)0xA1F5,
        /// <summary>  
        /// ■  
        /// </summary>  
        RECT_SOLID = (UInt16)0xA1F6,
        /// <summary>  
        /// △  
        /// </summary>  
        TRIANGLE_EMPTY = (UInt16)0xA1F7,
        /// <summary>  
        /// ▲  
        /// </summary>  
        TRIANGLE_SOLID = (UInt16)0xA1F8
    }

    /// <summary>  
    /// 符号辅助类  
    /// </summary>  
    internal sealed class CSymbolHelper
    {
        /// <summary>  
        /// 根据符号值获取字符串表示  
        /// </summary>  
        /// <param name="symbol"></param>  
        /// <returns></returns>  
        public static String getStringFromSymbol(CSymbol symbol)
        {
            UInt16 symbolVal = (UInt16)symbol;
            Byte[] bytes = { (Byte)((symbolVal & 0xFF00) >> 8), (Byte)(symbolVal & 0x00FF) };
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>  
        /// 获取符号十六进制表示  
        /// </summary>  
        /// <param name="symbol"></param>  
        /// <returns></returns>  
        public static String getSymbolHex(String symbol)
        {
            if (CText.getLength(symbol) > 2 || symbol == "")
            {
                throw new ArgumentOutOfRangeException("符号不能为空且长度不能超过2字节!");
            }

            String hex = "0x";
            Byte[] bytes = Encoding.Default.GetBytes(symbol);

            foreach (Byte b in bytes)
            {
                hex += String.Format("{0:X}", b);
            }

            return hex;
        }
    }
}
