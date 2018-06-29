using PacMan.Interfaces;

namespace PacMan
{
    public class Wall: ICoord, IGetChar
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
    }
}
