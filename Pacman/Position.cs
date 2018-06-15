using PacMan.Interfaces;

namespace PacMan
{
    public class Position: IPosition
    {
        public int X { get;set; }
        public int Y { get;set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y) ? true : false;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return (p1.X != p2.Y || p1.Y != p2.Y) ? true : false; ;
        }
    }
}
