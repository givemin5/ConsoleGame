using CEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class TestGame : CGame
    {
        private Boolean m_bkeydown = false;

        /// <summary>  
        /// 游戏初始化  
        /// </summary>  
        protected override void gameInit()
        {
            //设置游戏标题  
            setTitle("遊戲框架測試");
            //设置游戏画面刷新率 每毫秒一次  
            setUpdateRate(30);
            //设置光标隐藏  
            setCursorVisible(false);

            Console.WriteLine("遊戲初始化成功!");
        }

        /// <summary>  
        /// 游戏逻辑  
        /// </summary>  
        protected override void gameLoop()
        {

        }

        /// <summary>  
        /// 游戏结束  
        /// </summary>  
        protected override void gameExit()
        {
            Console.WriteLine("遊戲結束!");
            Console.ReadLine();
        }

        protected override void gameKeyDown(CKeyboardEventArgs e)
        {
            if (!m_bkeydown)
            {
                Console.WriteLine("按下鍵：" + e.getKey());

                m_bkeydown = true;
            }

            if (e.getKey() == CKeys.Escape)
            {
                setGameOver(true);
            }
        }

        protected override void gameKeyUp(CKeyboardEventArgs e)
        {
            Console.WriteLine("釋放鍵：" + e.getKey());
            m_bkeydown = false;
        }

        protected override void gameMouseAway(CMouseEventArgs e)
        {
            setTitle("游標離開了工作區!");
        }

        protected override void gameMouseDown(CMouseEventArgs e)
        {
            if (e.getKey() == CMouseButtons.Left)
            {
                Console.SetCursorPosition(15, 2);
                Console.WriteLine("游標工作區座標：" + e.ToString() + "  " + e.getKey().ToString());
            }
            else if (e.getKey() == CMouseButtons.Right)
            {
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("游標工作區座標：" + e.ToString() + "  " + e.getKey().ToString());
            }
            else if (e.getKey() == CMouseButtons.Middle)
            {
                Console.SetCursorPosition(15, 4);
                Console.WriteLine("游標工作區座標：" + e.ToString() + "  " + e.getKey().ToString());
            }
        }

        protected override void gameMouseMove(CMouseEventArgs e)
        {
            setTitle("游標回到工作區!");
        }
    }
}
