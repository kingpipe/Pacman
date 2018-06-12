namespace Pacman
{
    abstract public class Player:IPlayer
    {
        public Position position { get; set; }
        public Direction direction { get; set; }
        public Player()
        {
            direction = Direction.None;
        }
        public virtual bool MoveLeft(int [,] map)
        {
            if (map[position.X - 1, position.Y] != (int)Elements.Wall)
            {
                SwapPlacesX(map, position.X-1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight(int[,] map)
        {
            if (map[position.X + 1, position.Y] != (int)Elements.Wall)
            {
                SwapPlacesX(map, position.X+1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp(int[,] map)
        {
            if (map[position.X, position.Y - 1] != (int)Elements.Wall)
            {
                SwapPlacesY(map,position.Y-1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown(int[,] map)
        {
            if (map[position.X, position.Y + 1] != (int)Elements.Wall)
            {
                SwapPlacesY(map, position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int[,] map, int x)
        {
            int value = map[position.X, position.Y];
            map[position.X, position.Y] = map[x, position.Y];
            map[x, position.Y] = value;
            position.X = x;
        }
        private void SwapPlacesY(int[,] map, int y)
        {
            int value = map[position.X, position.Y];
            map[position.X, position.Y] = map[position.X, y];
            map[position.X, y] = value;
            position.Y = y;
        }
    }
}

