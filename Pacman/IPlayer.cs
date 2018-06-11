using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public interface IPlayer
    {
        bool MoveLeft(int[,] map);
        bool MoveRight(int[,] map);
        bool MoveUp(int[,] map);
        bool MoveDown(int[,] map);
    }
}
