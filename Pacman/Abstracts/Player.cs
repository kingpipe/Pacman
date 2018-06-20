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

        public virtual bool MoveLeft(int [,] map)
        {
            if (map[position.X - 1, position.Y] != Wall.GetNumberElement())
            {
                SwapPlacesX(map, position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight(int[,] map)
        {
            if (map[position.X + 1, position.Y] !=Wall.GetNumberElement())
            {
                SwapPlacesX(map, position.X+1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp(int[,] map)
        {
            if (map[position.X, position.Y - 1] != Wall.GetNumberElement())
            {
                SwapPlacesY(map,position.Y-1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown(int[,] map)
        {
            if (map[position.X, position.Y + 1] != Wall.GetNumberElement())
            {
                SwapPlacesY(map, position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int[,] map, int x)
        {
            int value = map[position.X, position.Y];
            map[position.X, position.Y] = Empty.GetNumberElement();//map[x, position.Y];
            map[x, position.Y] = value;
            position.X = x;
        }
        private void SwapPlacesY(int[,] map, int y)
        {
            int value = map[position.X, position.Y];
            map[position.X, position.Y] = Empty.GetNumberElement();//map[position.X, y];
            map[position.X, y] = value;
            position.Y = y;
        }
    }
}

