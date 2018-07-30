using PacMan.Interfaces;

namespace PacMan
{
    class Wall: ICoord
    {
        public Position Position { get; set; }

        public Wall(Position position)
        {
            Position = position;
        }

        public char GetCharElement()
        {
            return '#';
        }

        public string GetId()
        {
            return "wall";
        }
    }
}
