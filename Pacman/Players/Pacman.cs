using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Enums;
using System;
using System.Linq;
using System.Timers;

namespace PacMan.Players
{
    class Pacman : Player, IPacman, ISinkMoving
    {
        public override event Action<ICoord> Movement;
        public event Action SinkAboutCreateCherry;
        public event Action SinkAboutEatEnergizer;
        public event Action SinkAboutNextLevel;
        public event Action SinkAboutEatGhost;

        public Direction NewDirection { get; set; }
        public int Lives { get; set; }
        public int Count { get; set; }
        public int Level { get; set; }

        public Pacman(Map map, Position start) : base(map, start)
        {
            id = "pacman";
            idchar = 'P';

            timer = new Timer();
            Direction = Direction.None;
            NewDirection = Direction.None;
            Count = 0;
            Lives = 3;
            Level = 1;
        }

        public override void StartPosition()
        {
            Map[Position] = new Empty(Position);
            Movement(new Empty(Position));

            DefaultCoord();
            Map[Position] = this;
            Movement(this);
        }

        public override void Default(Map map)
        {
            base.Default(map);
            Direction = Direction.None;
            NewDirection = Direction.None;
            Level = 1;
            Count = 0;
            Lives = 3;
        }

        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(new Empty(Position));
            if (NewDirection != Direction)
            {
                if (Move(NewDirection))
                {
                    Direction = NewDirection;
                }
                else
                {
                    Move();
                }
            }
            else
            {
                Move();
            }
            Movement(Map[Position]);
            MaybeNextLevel();
        }

        public void Eat(IFood food)
        {
            if (food is IGhost ghost)
            {
                if (ghost.Frightened)
                {
                    Count += food.Score;
                    ghost.Restart();
                    SinkAboutEatGhost();
                }
            }
            else
            {
                if (food is Energizer)
                {
                    SinkAboutEatEnergizer();
                }
                Count += food.Score;
            }
            
            if (Count % 1000 == 700)
            {
                SinkAboutCreateCherry();
            }
        }

        public override bool Move()
        {
            return Move(Direction);
        }
        
        protected override bool MoveRight()
        {
            if (Position.X + 2 > Map.Widht)
            {
                Map[Position] = new Empty(Position);
                Position position = Position;
                position.X = 0;
                Position = position;
                Map[Position] = this;
                return true;
            }
            else
            {
                if (Map[Position.Right] is IFood food)
                    Eat(food);
                return base.MoveRight();
            }

        }

        protected override bool MoveLeft()
        {
            if (Position.X - 1 < 0)
            {
                Map[Position] = new Empty(Position);
                Position position = Position;
                position.X = Map.Height - 2;
                Position = position;
                Map[Position] = this;
                return true;
            }
            else
            {
                if (Map[Position.Left] is IFood food)
                    Eat(food);
                return base.MoveLeft();

            }
        }

        protected override bool MoveDown()
        {
            if (Map[Position.Down] is IFood food)
                Eat(food);
            return base.MoveDown();
        }

        protected override bool MoveUp()
        {
            if (Map[Position.Up] is IFood food)
                Eat(food);
            return base.MoveUp();
        }

        private void MaybeNextLevel()
        {
            var IsLittleGoal = Map.map.OfType<ICoord>().AsQueryable().Any(m => m is LittleGoal);
            if (!IsLittleGoal)
            {
                Level++;
                SinkAboutNextLevel();
            }
        }

        private bool Move(Direction direction)
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
    }
}