using PacMan.Players;
using System;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player
    {
        public Ghost() : base()
        {

        }

       protected Position PacmanPosition { get; set; }

        public void Move()
        {
            throw new NotImplementedException();
        }

        protected Position SearchPacman(int[,] map)
        {
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 32; x++)
                    if (map[x, y] == Pacman.GetNumberElement())
                        return new Position(x, y);
            return position;
        }
    }
}
