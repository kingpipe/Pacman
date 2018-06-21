using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman, IEateble
    {
        public int Lives { get; set; }
        public int Count { get; set; }

        public Pacman() : base()
        {
            Count = 0;
            Lives = 3;
            StartPosition();
        }
        public Pacman(Position position) : base()
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
        public bool Move(Direction direction, ICoord[,] map)
        {
            switch (direction)
            {
                case Direction.Left:
                    return MoveLeft(map);
                case Direction.Right:
                    return MoveRight(map);
                case Direction.Up:
                    return MoveUp(map);
                case Direction.Down:
                    return MoveDown(map);
                default:
                    return false;
            }
        }
        public override bool MoveRight(ICoord[,] map)
        {
            if (position.X + 3 > map.GetLength(1))
            {
                map[position.X, position.Y] = new Empty(position);
                position.X = 0;
                map[position.X, position.Y] = new Pacman(position);
                return true;
            }
            else
            {
                if (map[position.X + 1, position.Y] is IFood)
                    Eat(map[position.X + 1, position.Y]);
                return base.MoveRight(map);
            }

        }

        public override bool MoveLeft(ICoord[,] map)
        {
            if (position.X - 1 < 0)
            {
                map[position.X, position.Y] = new Empty(position);
                position.X = map.GetLength(0) - 1;
                map[position.X, position.Y] = new Pacman(position);
                return true;
            }
            else
            {
                if (map[position.X - 1, position.Y] is IFood)
                    Eat(map[position.X - 1, position.Y]);
                return base.MoveLeft(map);

            }
        }
        public override bool MoveDown(ICoord[,] map)
        {
            if (map[position.X, position.Y + 1] is IFood)
                Eat(map[position.X, position.Y + 1]);
            return base.MoveDown(map);
        }
        public override bool MoveUp(ICoord[,] map)
        {

            if (map[position.X, position.Y - 1] is IFood)
                Eat(map[position.X, position.Y - 1]);
            return base.MoveUp(map);
        }
        public static char GetCharElement()
        {
            return 'P';
        }

    }
}
