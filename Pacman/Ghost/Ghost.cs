using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Ghost:IPlayer
    {

        protected Position PacmanPosition;
        public Ghost():base()
        {
                
        }
        protected Position SearchPacman(int[,] map)
        {
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 32; x++)
                    if (map[x, y] == (int)Elements.Pacman)
                        return new Position(x, y);
            return position;
        }
    }
}
