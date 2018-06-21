using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;

namespace PacMan.Abstracts
{
    abstract public class Player : IMovable
    {
        public ICoord[,] Map { get; set; }
        public Position position { get; set; }
        public Direction direction { get; set; }

        public Player(ICoord[,] map)
        {
            Map = map;
            direction = Direction.None;
        }

        public virtual void StartPosition()
        {
            position = Position.None;
        }

        public virtual bool MoveLeft()
        {
            if (!(Map[position.X - 1, position.Y] is Wall))
            {
                SwapPlacesX(position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight()
        {
            if (!(Map[position.X + 1, position.Y] is Wall))
            {
                SwapPlacesX(position.X + 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp()
        {
            if (!(Map[position.X, position.Y - 1] is Wall))
            {
                SwapPlacesY(position.Y - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown()
        {
            if (!(Map[position.X, position.Y + 1] is Wall))
            {
                SwapPlacesY(position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int x)
        {
            var value = Map[position.X, position.Y];
            Map[position.X, position.Y] = new Empty(position);//map[x, position.Y];
            Map[x, position.Y] = value;
            position.X = x;
        }
        private void SwapPlacesY(int y)
        {
            var value = Map[position.X, position.Y];
            Map[position.X, position.Y] = new Empty(position);//map[position.X, y];
            Map[position.X, y] = value;
            position.Y = y;
        }
    }
}

