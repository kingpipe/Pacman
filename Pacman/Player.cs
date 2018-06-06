namespace Pacman
{
    abstract class Player
    {
        public Position position { get; set; }
        public Player(Position position)
        {
            this.position = position;
        }

    }
}
