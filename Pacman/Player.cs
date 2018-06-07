namespace Pacman
{
    abstract class Player
    {
        public Position position { get; set; }
        public Direction direction { get; set; }
        public Player(Position position)
        {
            this.position = position;
            direction = Direction.None;
        }

    }
}
