﻿using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                homePosition = new Position(Map.Widht - 4, 1);
                base.StartCoord = value;
            }
        }

        public Blinky(Map map, Position start) : base(map, start)
        {
            id = "blinky";
            idchar = 'B';
        }

        protected override void GoToCircle() => Strategy = new GoToClockwise(); 
    }
}
