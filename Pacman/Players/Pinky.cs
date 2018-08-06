﻿using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                homePosition = new Position(3, 1);
                base.StartCoord = value;
            }
        }

        public Pinky(Map map, Position start) : base(map, start)
        {
            id = "pinky";
            idchar = 'N';
        }
        public override void StrategyRunForPacman() => Strategy = new AstarAlgorithmOptimization();
        protected override void GoToCircle() => Strategy = new GoAgainstClockwise();
    }
}
