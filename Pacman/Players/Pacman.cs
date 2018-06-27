using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman, IEateble
    {
        public int Lives { get; set; }
        public int Count { get; set; }

        public Pacman(Map map) : base(map)
        {
            Count = 0;
            Lives = 3;
            StartPosition();
        }

        public override void StartPosition()
        {
            Position = new Position(15, 23);
        }

        public void Eat(ICoord coord)
        {
            if (coord is IGhost)
            {
                if (((IGhost)coord).Frightened == true)
                    Count += ((Ghost)coord).Score;
            }
            else
            {
                Count += ((IFood)coord).Score;
                ((IFood)coord).IsLive = false;
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
            if (Position.X + 3 > Map.Width)
            {
                Map.SetElement(new Empty(Position), Position);
                Position.X = 0;
                Map.SetElement(new Pacman(Map), Position);
                return true;
            }
            else
            {
                if (Map.GetElementRight(Position) is IFood)
                    Eat(Map.GetElementRight(Position));
                return base.MoveRight();
            }

        }

        public override bool MoveLeft()
        {
            if (Position.X - 1 < 0)
            {
                Map.SetElement(new Empty(Position), Position);
                Position.X = Map.Width - 1;
                Map.SetElement(new Pacman(Map), Position);
                return true;
            }
            else
            {
                if (Map.GetElementLeft(Position) is IFood)
                    Eat(Map.GetElementLeft(Position));
                return base.MoveLeft();

            }
        }
        public override bool MoveDown()
        {
            if (Map.GetElementDown(Position) is IFood)
                Eat(Map.GetElementDown(Position));
            return base.MoveDown();
        }
        public override bool MoveUp()
        {

            if (Map.GetElementUp(Position) is IFood)
                Eat(Map.GetElementUp(Position));
            return base.MoveUp();
        }
        public static char GetCharElement()
        {
            return 'P';
        }

    }
}
