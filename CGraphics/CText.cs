using System;
using System.Text;

namespace CGraphics
{
    /// <summary>  
    /// 字符串处理类  
    /// </summary>  
    sealed internal class CText
    {
        /// <summary>  
        /// 获取字符串字节长度  
        /// </summary>  
        /// <param name="text"></param>  
        /// <returns></returns>  
        public static Int32 getLength(String text)
        {
            Byte[] bytes;
            Int32 len = 0;
            for (Int32 i = 0; i < text.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(text.Substring(i, 1));
                len += bytes.Length > 1 ? 2 : 1;
            }
            return len;
        }

        /// <summary>  
        /// 按字节长度截字符串  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="len">字节长度</param>  
        /// <returns></returns>  
        public static String cutText(String text, Int32 len)
        {
            if (len < 0 || len > getLength(text))
            {
                throw new ArgumentOutOfRangeException();
            }

            Int32 charLen = 0;
            StringBuilder strb = new StringBuilder();

            for (Int32 i = 0; i < text.Length && charLen < len; i++)
            {
                charLen += getLength(text.Substring(i, 1));
                strb.Append(text[i]);
            }

            return strb.ToString();
        }

        /// <summary>  
        /// 按字符串索引并截取相应字节长度  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="index">字符串索引</param>  
        /// <param name="len">字节长度</param>  
        /// <returns></returns>  
        public static String indexOfText(String text, Int32 index, Int32 len)
        {
            if (index < 0 || index > text.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (len < 0 || len > getLength(text))
            {
                throw new ArgumentOutOfRangeException();
            }

            text = text.Substring(index, text.Length - index);

            return cutText(text, len);
        }

        /// <summary>  
        /// 字符串换行  
        /// </summary>  
        /// <param name="text">字符串</param>  
        /// <param name="cols">一列为2字节</param>  
        /// <returns></returns>  
        public static String lineBreakText(String text, Int32 cols)
        {
            if (cols < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Int32 len = 0;
            Int32 charLen = 0;
            StringBuilder strb = new StringBuilder();

            for (Int32 i = 0; i < text.Length; i++)
            {
                len = getLength(text.Substring(i, 1));
                charLen += len;

                if (charLen > (cols << 1))
                {
                    strb.Append(Environment.NewLine);
                    charLen = len;
                }

                strb.Append(text[i]);
            }

            return strb.ToString();
        }
    }
}
