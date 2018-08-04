using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                homePosition = new Position(Map.Widht - 4, Map.Height - 5);
                base.StartCoord = value;
            }
        }
        public Inky(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            GoToCircle = new GoToClockwise();

            id = "inky";
            idchar = 'I';
        }
    }
}
