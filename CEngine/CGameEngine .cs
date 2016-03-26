using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEngine
{
    public sealed class CGameEngine
    {
        public static void Run(ICGame game)
        {
            if (game == null)
            {
                Console.Write("引擎未初始化!");
                Console.ReadLine();
            }
            else
            {
                game.run();
            }
        }
    }
}
