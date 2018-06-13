using Pacman.Interfaces;

namespace Pacman
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
        //public bool OnMap()
        //{
        //    return X >= 0 && X < 32 && Y >= 0 && Y < 16;
        //}
        //public static bool operator ==(Position p1, Position p2)
        //{
        //    return (p1.X == p2.X && p1.Y == p2.Y) ? true : false;
        //}

        //public static bool operator !=(Position p1, Position p2)
        //{
        //    return (p1.X != p2.X || p1.Y != p2.Y) ? true : false; ;
        //}
    }
}
