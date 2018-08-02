using PacMan.Interfaces;

namespace PacMan
{
    public struct Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position Left => new Position(X - 1, Y);
        public Position Right => new Position(X + 1, Y);
        public Position Up => new Position(X, Y - 1);
        public Position Down => new Position(X, Y + 1);

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;

            Position p = (Position)obj;

            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
