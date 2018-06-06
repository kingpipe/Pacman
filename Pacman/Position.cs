namespace Pacman
{
    struct Position
    {
        public int X { get;set; }
        public int Y { get;set; }

        public int XminusOne => X--;
        public int XplusOne => X++;
        public int YminusOne => Y--;
        public int YplusOne =>Y++;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool OnMap()
        {
            return X >= 0 && X < 16 && Y >= 0 && Y < 16;
        }
    }
}
