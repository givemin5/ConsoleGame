using Game;
using CEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRun
{
    class Program
    {
        static void Main(string[] args)
        {
            CGameEngine.Run(new TestGame());
        }
    }
}
