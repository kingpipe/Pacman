using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman, IEateble, IGetChar
    {
        private bool value;

        public event Action<ICoord> Movement;
        public Direction direction { get; set; }
        public int Lives { get; set; }
        public int Count { get; set; }

        public Pacman()
        {
        }

        public Pacman(Map map) : base(map)
        {
            direction = Direction.None;
            Count = 0;
            Lives = 3;
        }

        public override void StartPosition()
        {
            Position = new Position(15, 23);
        }

        public void Start(Timer timer)
        {
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        public void Stop(Timer timer)
        {
            timer.Elapsed -= TimerElapsed;
            timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(new Empty(Position));
            value = Move();
            Movement(Map.GetElement(Position));
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
        public override bool Move()
        {
            switch (direction)
            {
                case Direction.Left:
                    value = MoveLeft();
                    break;
                case Direction.Right:
                    value = MoveRight();
                    break;
                case Direction.Up:
                    value = MoveUp();
                    break;
                case Direction.Down:
                    value = MoveDown();
                    break;
                default:
                    direction = Direction.None;
                    value = false;
                    break;
            }
            return value;
        }
        public override bool MoveRight()
        {
            if (Position.X + 2 > Map.Width)
            {
                Map.SetElement(new Empty(Position));
                Position position = Position;
                position.X = 0;
                Position = position;
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
                Map.SetElement(new Empty(Position));
                Position position = Position;
                position.X = Map.Height - 2;
                Position = position;
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
        public override char GetCharElement()
        {
            return 'P';
        }

    }
}
