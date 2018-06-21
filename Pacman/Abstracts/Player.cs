using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;

namespace PacMan.Abstracts
{
    abstract public class Player:IMovable
    {
        public Position position { get; set; }
        public Direction direction { get; set; }

        public Player()
        {
            direction = Direction.None;
        }

        public virtual void StartPosition()
        {
            position = Position.None;
        }

        public virtual bool MoveLeft(ICoord [,] map)
        {
            if (!(map[position.X - 1, position.Y] is Wall))
            {
                SwapPlacesX(map, position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight(ICoord[,] map)
        {
            if (!(map[position.X + 1, position.Y] is Wall))
            {
                SwapPlacesX(map, position.X+1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp(ICoord[,] map)
        {
            if (!(map[position.X, position.Y - 1] is Wall))
            {
                SwapPlacesY(map,position.Y-1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown(ICoord[,] map)
        {
            if (!(map[position.X, position.Y + 1] is Wall))
            {
                SwapPlacesY(map, position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(ICoord[,] map, int x)
        {
            var value = map[position.X, position.Y];
            map[position.X, position.Y] = new Empty(position);//map[x, position.Y];
            map[x, position.Y] = value;
            position.X = x;
        }
        private void SwapPlacesY(ICoord[,] map, int y)
        {
            var value = map[position.X, position.Y];
            map[position.X, position.Y] = new Empty(position);//map[position.X, y];
            map[position.X, y] = value;
            position.Y = y;
        }
    }
}

