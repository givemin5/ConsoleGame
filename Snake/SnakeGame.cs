using System;
using CEngine;
using CGraphics;

namespace Snake
{
    /// <summary>  
    /// 贪吃蛇游戏类  
    /// </summary>  
    public sealed class SnakeGame : CGame
    {
        /// <summary>  
        /// 游戏状态  
        /// </summary>  
        public enum GameState
        {
            /// <summary>  
            /// 初始化  
            /// </summary>  
            Init,
            /// <summary>  
            /// 开始游戏  
            /// </summary>  
            Start,
            /// <summary>  
            /// 暂停游戏  
            /// </summary>  
            Pause,
            /// <summary>  
            /// 结束游戏  
            /// </summary>  
            End
        }

        /// <summary>  
        /// 贪吃蛇  
        /// </summary>  
        private Snake g_snake;
        /// <summary>  
        /// 食物  
        /// </summary>  
        private Food g_food;
        /// <summary>  
        /// 随机数  
        /// </summary>  
        private Random g_random;
        /// <summary>  
        /// 分数  
        /// </summary>  
        private Int32 g_score;
        /// <summary>  
        /// 生命  
        /// </summary>  
        private Int32 g_lifes;
        /// <summary>  
        /// 状态  
        /// </summary>  
        private GameState g_state;


        #region 游戏运行函数  

        /// <summary>  
        /// 游戏初始化  
        /// </summary>  
        protected override void gameInit()
        {
            base.setTitle("控制台遊戲之———簡易貪吃蛇v1.0");
            base.setCursorVisible(false);
            base.setUpdateRate(50);

            this.g_random = new Random();
            this.g_snake = new Snake(3, CDirection.Right);
            this.g_food = new Food();

            this.g_lifes = 3;
            this.g_state = GameState.Init;

            this.drawInitUI();
        }

        /// <summary>  
        /// 游戏重绘时响应  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void onRedraw(CPaintEventArgs e)
        {
            base.onRedraw(e);

            CDraw draw = e.getDraw();
            //绘制食物  
            g_food.draw(draw);
            //绘制数据  
            draw.drawText("得分：" + g_score.ToString(), 63, 2, ConsoleColor.Green);
            draw.drawText("生命：" + g_lifes.ToString(), 63, 4, ConsoleColor.Red);
        }

        /// <summary>  
        /// 游戏渲染  
        /// </summary>  
        /// <param name="draw"></param>  
        protected override void gameDraw(CGraphics.CDraw draw)
        {
            if (g_state == GameState.Start)
            {
                g_snake.draw(draw);
                draw.drawText("FPS：" + getFPS(), 63, 6, ConsoleColor.Blue);
            }
        }

        /// <summary>  
        /// 游戏逻辑  
        /// </summary>  
        protected override void gameLoop()
        {
            //游戏开始状态  
            if (g_state == GameState.Start)
            {
                //如果蛇能爬行或者没有自残则爬行  
                if (g_snake.move() && !g_snake.isSeftCollision())
                {
                    //吃到食物  
                    if (g_snake.getHead() == g_food.getPosition())
                    {
                        //加10分  
                        this.g_score += 10;
                        //蛇长大  
                        g_snake.addBodyNode(g_food.getPosition(), true);
                        //创建新食物  
                        createFood();
                    }
                }
                else
                {
                    //蛇死亡，减一条生命  
                    this.g_lifes--;

                    //扣分算法  
                    if (this.g_score > 20)
                    {
                        this.g_score -= 20;
                    }

                    //延时一秒钟  
                    base.delay(1000);

                    //蛇回到原始状态  
                    this.g_snake = new Snake(3, CDirection.Right);
                    //更新导致重绘区域  
                    base.update(new CRect(1, 1, 28, 23));

                    //游戏结束  
                    if (this.g_lifes == 0)
                    {
                        this.g_state = GameState.End;

                        this.setGameOver(true);
                    }
                }
            }
        }

        /// <summary>  
        /// 游戏结束  
        /// </summary>  
        protected override void gameExit()
        {
            drawEndUI();

            g_snake = null;
            g_food = null;
        }

        /// <summary>  
        /// 键盘事件  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void gameKeyDown(CKeyboardEventArgs e)
        {
            if (g_snake != null)
            {
                if (e.getKey() == CKeys.Left)
                {
                    if (g_snake.getDirection() != CDirection.Right)
                    {
                        g_snake.setDirection(CDirection.Left);
                    }
                }
                else if (e.getKey() == CKeys.Right)
                {
                    if (g_snake.getDirection() != CDirection.Left)
                    {
                        g_snake.setDirection(CDirection.Right);
                    }
                }
                else if (e.getKey() == CKeys.Up)
                {
                    if (g_snake.getDirection() != CDirection.Down)
                    {
                        g_snake.setDirection(CDirection.Up);
                    }
                }
                else if (e.getKey() == CKeys.Down)
                {
                    if (g_snake.getDirection() != CDirection.Up)
                    {
                        g_snake.setDirection(CDirection.Down);
                    }
                }
                else if (e.getKey() == CKeys.Space)
                {
                    if (g_state == GameState.Init)
                    {
                        g_state = GameState.Start;

                        drawStartUI();
                    }
                    else if (g_state == GameState.Pause)
                    {
                        g_state = GameState.Start;
                    }
                    else if (g_state == GameState.Start)
                    {
                        g_state = GameState.Pause;
                    }
                }
                else if (e.getKey() == CKeys.Escape)
                {
                    setGameOver(true);
                }
            }
        }

        #endregion

        /// <summary>  
        /// 创建食物  
        /// </summary>  
        private void createFood()
        {
            CPoint point = new CPoint(g_random.Next(1, 29), g_random.Next(1, 24));
            //防止食物出现在蛇身  
            while (g_snake.isCollision(point))
            {
                point.setX(g_random.Next(1, 29));
                point.setY(g_random.Next(1, 24));
            }

            g_food.setPosition(point);
            //调用更新函数导致控制台重绘  
            base.update(new CRect(point.getX(), point.getY(), 1, 1));
        }

        #region 绘制界面  

        //绘制游戏初始界面  
        private void drawInitUI()
        {
            CDraw draw = base.getDraw();
            draw.clear(ConsoleColor.Black);
            draw.setDrawSymbol(CSymbol.RECT_EMPTY);
            draw.drawRect(6, 4, 29, 12, ConsoleColor.DarkBlue);
            draw.fillRect(7, 5, 27, 10, ConsoleColor.Blue);
            draw.drawText("<<C#控制台遊戲系列>>", 16, 5, ConsoleColor.White);
            draw.drawText("簡 易 貪 吃 蛇", 34, 9, ConsoleColor.Yellow);
            draw.drawText("Copyright. D-Zone Studio", 42, 14, ConsoleColor.Gray);
            draw.drawText("Space to Play", 35, 20, ConsoleColor.White);
        }

        //绘制游戏开始界面  
        private void drawStartUI()
        {
            CDraw draw = base.getDraw();
            //绘制界面  
            draw.clear(ConsoleColor.Black);
            draw.setDrawSymbol(CSymbol.RECT_EMPTY);
            draw.drawRect(0, 0, 30, 25, ConsoleColor.White);
            draw.setDrawSymbol(CSymbol.RHOMB_SOLID);
            draw.drawRect(30, 0, 10, 25, ConsoleColor.DarkYellow);
            draw.drawText("操作：鍵盤操作，方向鍵控制貪吃蛇爬行方向，空格鍵控制開始遊戲和暫停遊戲，ESC鍵退出遊戲。", new CRect(32, 14, 6, 10), ConsoleColor.DarkGreen);
            this.createFood();
        }

        //绘制游戏结束界面  
        private void drawEndUI()
        {
            CDraw draw = base.getDraw();
            //绘制界面  
            draw.clear(ConsoleColor.Black);
            draw.drawText("Game over, ", 30, 10, ConsoleColor.White);
            draw.drawText("score：" + g_score.ToString(), 42, 10, ConsoleColor.White);
            Console.ReadLine();
        }

        #endregion
    }
}