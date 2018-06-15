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

        public static int GetNumberElement()
        {
            return 1;
        }

        public static char GetCharElement()
        {
            return '#';
        }
    }
}
