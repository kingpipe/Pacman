using PacMan.Interfaces;
using PacMan.Players;
using System;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player, IGhost
    {
        public bool Frightened { get; set; }
        protected Position PacmanPosition { get; set; }

        public Ghost() : base()
        {

        }

        public virtual bool Move(ICoord[,] map)
        {
            throw new NotImplementedException();
        }

        protected Position SearchPacman(ICoord[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
                for (int x = 0; x < map.GetLength(0); x++)
                    if (map[x, y] is Pacman)
                        return new Position(x, y);
            return position;
        }
    }
}
