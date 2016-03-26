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
        private Int32 m_ticks;
        private Int32 m_lasttime;

        /// <summary>  
        /// 游戏初始化  
        /// </summary>  
        protected override void gameInit()
        {
            //设置游戏标题  
            setTitle("遊戲框架測試");
            //设置游戏画面刷新率 每毫秒一次  
            setUpdateRate(1000);
            //设置光标隐藏  
            setCursorVisible(false);

            Console.WriteLine("遊戲初始化成功!");

            m_lasttime = Environment.TickCount;
        }

        /// <summary>  
        /// 游戏逻辑  
        /// </summary>  
        protected override void gameLoop()
        {
            if (m_ticks++ < 15)
            {
                Console.WriteLine(string.Format("  遊戲運行中,第{0}禎,耗時{1}ms", m_ticks, Environment.TickCount - m_lasttime));
                m_lasttime = Environment.TickCount;
            }
            else
            {
                setGameOver(true);
            }
        }

        /// <summary>  
        /// 游戏结束  
        /// </summary>  
        protected override void gameExit()
        {
            Console.WriteLine("遊戲結束!");
            Console.ReadLine();
        }
    }
}
