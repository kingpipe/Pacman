using PacMan.Interfaces;


namespace PacMan
{
    public class Wall: ICoord
    {
        public Position position { get; set; }

        public Wall(Position position)
        {
            this.position = position;
        }

        public static char GetCharElement()
        {
            return '#';
        }
    }
}
