﻿using PacMan.Interfaces;
using PacMan.Players;
using System;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player, IGhost, IFood, IEventSink
    {
        public abstract event Action SinkAboutEatPacman;
        protected ICoord oldcoord;
        public bool Frightened { get; set; }
        protected Position PacmanPosition { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }
        protected bool PacmanIsLive = true;

        public Ghost(Map map) : base(map)
        {
            PacmanPosition = SearchPacman();
            Score = 200;
            IsLive = true;
            Frightened = false;
        }

        public virtual bool Move()
        {
            throw new NotImplementedException();
        }

        protected Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    if (Map.map[x, y] is Pacman)
                        return new Position(x, y);
            return PacmanPosition;
        }
    }
}
