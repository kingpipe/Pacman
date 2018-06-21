using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman, IEateble
    {
        public int Lives { get; set; }
        public int Count { get; set; }

        public Pacman(ICoord[,] map) : base(map)
        {
            Count = 0;
            Lives = 3;
            StartPosition();
        }
        public Pacman(Position position, ICoord[,] map) : base(map)
        {
            this.position = position;
        }
        public override void StartPosition()
        {
            position = new Position(15, 23);
        }

        public void Eat(ICoord coord)
        {
            if (coord is IGhost)
            {
                Count += ((Ghost)coord).Score;

            }
            else
            {
                Count += ((IFood)coord).Score;
            }

        }
        public bool Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return MoveLeft();
                case Direction.Right:
                    return MoveRight();
                case Direction.Up:
                    return MoveUp();
                case Direction.Down:
                    return MoveDown();
                default:
                    return false;
            }
        }
        public override bool MoveRight()
        {
            if (position.X + 3 > Map.GetLength(1))
            {
                Map[position.X, position.Y] = new Empty(position);
                position.X = 0;
                Map[position.X, position.Y] = new Pacman(position, Map);
                return true;
            }
            else
            {
                if (Map[position.X + 1, position.Y] is IFood)
                    Eat(Map[position.X + 1, position.Y]);
                return base.MoveRight();
            }

        }

        public override bool MoveLeft()
        {
            if (position.X - 1 < 0)
            {
                Map[position.X, position.Y] = new Empty(position);
                position.X = Map.GetLength(0) - 1;
                Map[position.X, position.Y] = new Pacman(position, Map);
                return true;
            }
            else
            {
                if (Map[position.X - 1, position.Y] is IFood)
                    Eat(Map[position.X - 1, position.Y]);
                return base.MoveLeft();

            }
        }
        public override bool MoveDown()
        {
            if (Map[position.X, position.Y + 1] is IFood)
                Eat(Map[position.X, position.Y + 1]);
            return base.MoveDown();
        }
        public override bool MoveUp()
        {

            if (Map[position.X, position.Y - 1] is IFood)
                Eat(Map[position.X, position.Y - 1]);
            return base.MoveUp();
        }
        public static char GetCharElement()
        {
            return 'P';
        }

    }
}
