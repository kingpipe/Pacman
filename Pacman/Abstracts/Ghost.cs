using PacMan.Interfaces;
using PacMan.Players;
using System;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player, IGhost, IFood
    {
        public bool Frightened { get; set; }
        protected Position PacmanPosition { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        public Ghost(ICoord [,] map) : base(map)
        {
            Score = 200;
            IsLive = true;
            Frightened = false;
        }

        public virtual bool Move()
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
