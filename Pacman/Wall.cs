using PacMan.Interfaces;

namespace PacMan
{
    class Wall: ICoord
    {
        public Position Position { get; set; }

        public Wall()
        { }

        public Wall(Position position)
        {
            Position = position;
        }

        public char GetCharElement()
        {
            return '#';
        }
    }
}
