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

        protected virtual bool MoveLeft(Game game, Elements elements)
        {
            if (game.map[position.X - 1, position.Y] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X - 1, position.Y] = (int)elements;
                position.X = position.X - 1;
                return true;
            }
            return false;
        }

        protected virtual bool MoveRight(Game game, Elements elements)
        {
            if (game.map[position.X + 1, position.Y] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X + 1, position.Y] = (int)elements;
                position.X = position.X + 1;
                return true;
            }
            return false;
        }

        protected virtual bool MoveUp(Game game, Elements elements)
        {
            if (game.map[position.X, position.Y - 1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y - 1] = (int)elements;
                position.Y = position.Y - 1;
                return true;
            }
            return false;
        }

        protected virtual bool MoveDown(Game game, Elements elements)
        {
            if (game.map[position.X, position.Y + 1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y + 1] = (int)elements;
                position.Y = position.Y + 1;
                return true;
            }
            return false;
        }
    }
}

