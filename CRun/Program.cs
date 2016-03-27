using Game;
using CEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGraphics;

namespace CRun
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化一个绘图对象  
            CDraw draw = new CDraw();

            //绘制字符串  
            draw.drawText("測試點結構", 2, 1, ConsoleColor.Blue);
            //初始化一个点point1  
            CPoint point1 = new CPoint(1, 2);
            //初始化一个点point2  
            CPoint point2 = new CPoint(3, 4);
            //绘制point1  
            draw.drawText("點1：" + point1, 4, 2, ConsoleColor.White);
            //绘制point2  
            draw.drawText("點2：" + point2, 4, 3, ConsoleColor.White);
            //绘制两点相加  
            draw.drawText("點1+點2：" + (point1 + point2), 4, 4, ConsoleColor.White);
            //绘制两点相减  
            draw.drawText("點1-點2：" + (point1 - point2), 4, 5, ConsoleColor.White);
            //绘制两点是否相等  
            draw.drawText("點1==點2：" + (point1 == point2), 4, 6, ConsoleColor.White);
            //绘制两点是否不等  
            draw.drawText("點1!=點2：" + (point1 != point2), 4, 7, ConsoleColor.White);


            //绘制字符串  
            draw.drawText("測試矩形結構", 1, 9, 2, 3, ConsoleColor.Red);
            //初始化一个矩形  
            CRect rect = new CRect(2, 2, 5, 8);
            draw.drawText("矩形：" + rect, 4, 12, ConsoleColor.White);
            //缩放矩形  
            rect.inflate(1, 1);
            draw.drawText("矩形縮放[1,1]：" + rect, 4, 13, ConsoleColor.White);

            //设置绘制符号  
            draw.setDrawSymbol(CSymbol.RECT_SOLID);
            draw.drawRect(15, 0, 25, 25, ConsoleColor.White);
            //绘制字符串  
            draw.drawText("測試矩形結構", 32, 1, ConsoleColor.Green);

            //初始化一个矩阵  
            CMatrix matrix1 = new CMatrix(3, 3);
            matrix1[0, 0] = 1;
            matrix1[2, 2] = 3;
            matrix1[0, 1] = 1;
            //初始化一个矩阵  
            CMatrix matrix2 = new CMatrix(new Int32[3, 3]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            });
            //初始化一个矩阵  
            CMatrix matrix3 = new CMatrix(new Int32[2, 3]
            {
                {1,2,3},
                {4,5,6}
            });
            //绘制矩阵  
            draw.drawText("矩陣1：", 32, 2, ConsoleColor.White);
            draw.drawText(matrix1.ToString(), 16, 3, 5, 3, ConsoleColor.White);
            //绘制矩阵  
            draw.drawText("矩陣2：", 42, 2, ConsoleColor.White);
            draw.drawText(matrix2.ToString(), 21, 3, 5, 3, ConsoleColor.White);
            //绘制矩阵  
            draw.drawText("矩陣3：", 52, 2, ConsoleColor.White);
            draw.drawText(matrix3.ToString(), 26, 3, 5, 3, ConsoleColor.White);

            //绘制矩阵  
            draw.drawText("矩陣1+矩陣2：", 32, 7, ConsoleColor.White);
            draw.drawText((matrix1 + matrix2).ToString(), 16, 8, 5, 3, ConsoleColor.White);
            //绘制矩阵  
            draw.drawText("矩陣2-矩陣1：", 48, 7, ConsoleColor.White);
            draw.drawText((matrix2 - matrix1).ToString(), 24, 8, 5, 3, ConsoleColor.White);
            //绘制矩阵  
            draw.drawText("矩陣3*矩陣2：", 64, 7, ConsoleColor.White);
            draw.drawText((matrix3 * matrix2).ToString(), 32, 8, 7, 3, ConsoleColor.White);

            //顺时针旋转矩阵90度   
            matrix2.rotate(CRotateMode.R90);
            draw.drawText("順時針90度旋轉矩陣2：", 32, 12, ConsoleColor.White);
            draw.drawText(matrix2.ToString(), 16, 13, 5, 3, ConsoleColor.White);

            //为了测试先恢复矩阵状态  
            matrix2.rotate(CRotateMode.L90);
            //顺时针旋转矩阵180度  
            matrix2.rotate(CRotateMode.R180);
            draw.drawText("順時針180度旋轉矩陣2：", 54, 12, ConsoleColor.White);
            draw.drawText(matrix2.ToString(), 27, 13, 5, 3, ConsoleColor.White);

            //为了测试先恢复矩阵状态  
            matrix2.rotate(CRotateMode.L180);
            //顺时针旋转矩阵270度  
            matrix2.rotate(CRotateMode.R270);
            draw.drawText("順時針270度旋轉矩陣2：", 32, 17, ConsoleColor.White);
            draw.drawText(matrix2.ToString(), 16, 18, 5, 3, ConsoleColor.White);

            matrix3.rotate(CRotateMode.L90);
            draw.drawText("逆時針90度旋轉矩陣3：", 54, 17, ConsoleColor.White);
            draw.drawText(matrix3.ToString(), 27, 18, 4, 4, ConsoleColor.White);

            //设置绘制符号  
            draw.setDrawSymbol(CSymbol.RECT_EMPTY);
            //填充矩形  
            draw.fillRect(2, 15, 5, 5, ConsoleColor.Yellow);
            //设置绘制符号  
            draw.setDrawSymbol(CSymbol.RHOMB_SOLID);
            //填充矩形  
            draw.fillRect(3, 16, 2, 3, ConsoleColor.Blue);
            //设置绘制符号  
            draw.setDrawSymbol(CSymbol.RECT_SOLID);
            //填充矩形  
            draw.fillRect(7, 17, 4, 3, ConsoleColor.Blue);

            //绘制一段文字  
            draw.drawText("C#遊戲編程：《控制台小遊戲系列》之《四、遊戲渲染模組》", 2, 21, 12, 5, ConsoleColor.Cyan);

            Console.ReadLine();
        }
    }
}
