using System;

namespace CEngine
{
    [Flags]
    public enum CDirection
    {
        Left = 0x01,
        Right = 0x02,
        Up = 0x04,
        Down = 0x08,
        None = 0
    }
}