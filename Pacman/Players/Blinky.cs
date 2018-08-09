using PacMan.Abstracts;
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
                base.StartCoord = value;
                homePosition = new Position(Map.Widht - 4, 1);
            }
        }

        public Blinky(Position start, Map map) : base(start, map)
        {
            id = "blinky";
            idchar = 'B';
        }

        protected override void GoToCircle() => Strategy = new GoToClockwise(); 
    }
}
