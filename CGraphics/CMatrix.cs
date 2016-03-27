using System;
using System.Text;

namespace CGraphics
{
    /// <summary>  
    /// 旋转方式  
    /// </summary>  
    public enum CRotateMode
    {
        /// <summary>  
        /// 不旋转  
        /// </summary>  
        None,
        /// <summary>  
        /// 顺时针旋转90度  
        /// </summary>  
        R90,
        /// <summary>  
        /// 顺时针旋转180度  
        /// </summary>  
        R180,
        /// <summary>  
        /// 顺时针旋转270度  
        /// </summary>  
        R270,
        /// <summary>  
        /// 逆时针旋转90度  
        /// </summary>  
        L90,
        /// <summary>  
        /// 逆时针旋转180度  
        /// </summary>  
        L180,
        /// <summary>  
        /// 逆时针旋转270度  
        /// </summary>  
        L270
    }

    /// <summary>  
    /// 矩阵结构  
    /// </summary>  
    public struct CMatrix
    {
        /// <summary>  
        /// 矩阵元素  
        /// </summary>  
        private Int32[,] m_matrix;
        /// <summary>  
        /// 矩阵行数  
        /// </summary>  
        private Int32 m_rows;
        /// <summary>  
        /// 矩阵列数  
        /// </summary>  
        private Int32 m_cols;
        /// <summary>  
        /// 矩阵总元素  
        /// </summary>  
        private Int32 m_totalCount;
        /// <summary>  
        /// 旋转方式  
        /// </summary>  
        private CRotateMode m_rotate;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="matrix"></param>  
        public CMatrix(Int32[,] matrix)
        {
            this.m_matrix = matrix;
            this.m_rows = matrix.GetUpperBound(0) + 1;
            this.m_cols = matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = CRotateMode.None;
        }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="row"></param>  
        /// <param name="col"></param>  
        public CMatrix(Int32 row, Int32 col)
        {
            this.m_matrix = new Int32[row, col];
            this.m_rows = m_matrix.GetUpperBound(0) + 1;
            this.m_cols = m_matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = CRotateMode.None;
        }

        /// <summary>  
        /// 可以通过索引操作  
        /// </summary>  
        /// <param name="x"></param>  
        /// <param name="y"></param>  
        /// <returns></returns>  
        public Int32 this[Int32 x, Int32 y]
        {
            get
            {
                if (x < 0 || y < 0 || x > m_rows - 1 || y > m_cols - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return m_matrix[x, y];
            }
            set
            {
                if (x < 0 || y < 0 || x > m_rows - 1 || y > m_cols - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                m_matrix[x, y] = value;
            }
        }

        /// <summary>  
        /// 获取矩阵数组  
        /// </summary>  
        /// <returns></returns>  
        public Int32[,] getMatrixArray()
        {
            return this.m_matrix;
        }

        /// <summary>  
        /// 设置矩阵  
        /// </summary>  
        /// <param name="matrix"></param>  
        public void setMatrix(Int32[,] matrix)
        {
            this.m_matrix = matrix;
            this.m_rows = matrix.GetUpperBound(0) + 1;
            this.m_cols = matrix.GetUpperBound(1) + 1;
            this.m_totalCount = m_rows * m_cols;
            this.m_rotate = CRotateMode.None;
        }

        /// <summary>  
        /// 获取矩阵行数  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getRows()
        {
            return this.m_rows;
        }

        /// <summary>  
        /// 获取矩阵列数  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getCols()
        {
            return this.m_cols;
        }

        /// <summary>  
        /// 获取矩阵元素总个数  
        /// </summary>  
        /// <returns></returns>  
        public Int32 getTotalCount()
        {
            return m_totalCount;
        }

        /// <summary>  
        /// 设置旋转方式  
        /// </summary>  
        /// <param name="mode"></param>  
        /// <returns></returns>  
        public void setRotateMode(CRotateMode mode)
        {
            this.m_rotate = mode;
        }

        /// <summary>  
        /// 两矩阵相加  
        /// </summary>  
        /// <param name="left"></param>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public static CMatrix operator +(CMatrix left, CMatrix right)
        {
            if ((left.getRows() != right.getRows()) ||
                (left.getCols() != right.getCols()))
            {
                throw new CMatrixException("error");
            }

            Int32 r = left.getRows();
            Int32 c = left.getCols();

            CMatrix newMatrix = new CMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = left[i, j] + right[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>  
        /// 矩阵相加  
        /// </summary>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public CMatrix add(CMatrix right)
        {
            return this + right;
        }

        /// <summary>  
        /// 两矩阵相减  
        /// </summary>  
        /// <param name="left"></param>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public static CMatrix operator -(CMatrix left, CMatrix right)
        {
            if ((left.getRows() != right.getRows()) ||
               (left.getCols() != right.getCols()))
            {
                throw new CMatrixException("error");
            }

            Int32 r = left.getRows();
            Int32 c = left.getCols();

            CMatrix newMatrix = new CMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = left[i, j] - right[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>  
        /// 矩阵相减  
        /// </summary>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public CMatrix sub(CMatrix right)
        {
            return this - right;
        }

        /// <summary>  
        /// 两矩阵相乘  
        /// </summary>  
        /// <param name="left"></param>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public static CMatrix operator *(CMatrix left, CMatrix right)
        {
            //左矩阵列数等于右矩阵的行数时才能执行相乘运算  
            if (left.getCols() != right.getRows())
            {
                throw new CMatrixException("error");
            }

            Int32 lr = left.getRows();
            Int32 lc = left.getCols();
            Int32 rc = right.getCols();

            CMatrix newMatrix = new CMatrix(lr, rc);

            for (Int32 i = 0; i < lr; i++)
            {
                for (Int32 j = 0; j < rc; j++)
                {
                    for (Int32 z = 0; z < lc; z++)
                    {
                        newMatrix[i, j] = newMatrix[i, j] + left[i, z] * right[z, j];
                    }
                }
            }

            return newMatrix;
        }

        /// <summary>  
        /// 矩阵相乘  
        /// </summary>  
        /// <param name="right"></param>  
        /// <returns></returns>  
        public CMatrix multiply(CMatrix right)
        {
            return this * right;
        }

        /// <summary>  
        /// 矩阵旋转  
        /// </summary>  
        /// <returns></returns>  
        public void rotate()
        {
            rotate(this.m_rotate);
        }

        /// <summary>  
        /// 矩阵旋转  
        /// </summary>  
        /// <param name="mode">旋转模式</param>  
        /// <returns></returns>  
        public void rotate(CRotateMode mode)
        {
            switch (mode)
            {
                case CRotateMode.None:
                    break;
                case CRotateMode.R90:
                    rotateR90();
                    break;
                case CRotateMode.R180:
                    rotateR180();
                    break;
                case CRotateMode.R270:
                    rotateR270();
                    break;
                case CRotateMode.L90:
                    rotateL90();
                    break;
                case CRotateMode.L180:
                    rotateL180();
                    break;
                case CRotateMode.L270:
                    rotateL270();
                    break;
                default:
                    break;
            }
        }

        #region 矩阵旋转函数  

        /// <summary>  
        /// 顺时针旋转90  
        /// </summary>  
        /// <returns></returns>  
        private void rotateR90()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[r - j - 1, i];
                }
            }

            this = newMatrix;
        }
        /// <summary>  
        /// 顺时针旋转180  
        /// </summary>  
        /// <returns></returns>  
        private void rotateR180()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = this[r - i - 1, c - j - 1];
                }
            }

            this = newMatrix;
        }
        /// <summary>  
        /// 顺时针旋转270  
        /// </summary>  
        /// <returns></returns>  
        private void rotateR270()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[j, c - i - 1];
                }
            }

            this = newMatrix;
        }
        /// <summary>  
        /// 逆时针旋转90  
        /// </summary>  
        /// <returns></returns>  
        private void rotateL90()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[j, c - i - 1];
                }
            }

            this = newMatrix;
        }
        /// <summary>  
        /// 逆时针旋转180  
        /// </summary>  
        /// <returns></returns>  
        private void rotateL180()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(r, c);

            for (Int32 i = 0; i < r; i++)
            {
                for (Int32 j = 0; j < c; j++)
                {
                    newMatrix[i, j] = this[r - i - 1, c - j - 1];
                }
            }

            this = newMatrix;
        }
        /// <summary>  
        /// 逆时针旋转270  
        /// </summary>  
        /// <returns></returns>  
        private void rotateL270()
        {
            Int32 r = this.getRows();
            Int32 c = this.getCols();

            CMatrix newMatrix = new CMatrix(c, r);

            for (Int32 i = 0; i < c; i++)
            {
                for (Int32 j = 0; j < r; j++)
                {
                    newMatrix[i, j] = this[r - j - 1, i];
                }
            }

            this = newMatrix;
        }

        #endregion

        /// <summary>  
        /// 输出矩阵  
        /// </summary>  
        /// <returns></returns>  
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            for (Int32 i = 0; i < getRows(); i++)
            {
                for (Int32 j = 0; j < getCols(); j++)
                {
                    strB.Append(m_matrix[i, j] + "  ");
                }
                strB.Append(Environment.NewLine);
            }
            return strB.ToString();
        }
    }

    /// <summary>  
    /// 自定义异常  
    /// </summary>  
    public class CMatrixException : Exception
    {
        public CMatrixException()
            : base()
        {

        }

        public CMatrixException(String msg)
            : base(msg)
        {

        }

        public String getMessage()
        {
            return base.Message;
        }
    }
}