using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.Collections.Generic;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player, IGhost, IFood, ISinkAboutEatPacman
    {
        public abstract event Action SinkAboutEatPacman;
        
        protected object obj = new object();
        protected bool pacmanIsLive = true;
        protected Stack<Position> path;

        public IStrategy strategy;
        public ICoord oldcoord;
        public Position PacmanPosition { get; set; }
        public bool Frightened { get; set; }
        public int Score { get; set; }

        public Ghost()
        { }

        public Ghost(Map map) : base(map)
        {
            PacmanPosition = SearchPacman();
            path = new Stack<Position>();
            oldcoord = new Empty(Position);

            Score = 200;
            Frightened = false;
        }
        
        protected Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    if (Map.map[x, y] is Pacman)
                        return new Position(x, y);
            return PacmanPosition;
        }

        protected virtual ICoord Go(Stack<Position> list, ICoord coord)
        {
            Map.SetElement(coord);
            if (list.Count != 0)
                Position = list.Pop();
            ICoord old = Map.GetElement(Position);
            Map.SetElement(this);
            return old;
        }

        protected bool GhostIsFrightened()
        {
            if (Frightened)
                return true;
            else
            {
                oldcoord = new Empty(Position);
                return false;
            }
        }
    }
}
