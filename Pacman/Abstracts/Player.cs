using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract public class Player : IMovable
    {
        public Map Map { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public Player()
        {
        }

        public Player(Map map)
        {
            StartPosition();
            Map = map;
            Direction = Direction.None;
        }

        public virtual void StartPosition()
        {
            Position = Position.None;
        }

        public virtual bool MoveLeft()
        {
            if (!(Map.GetElementLeft(Position) is Wall))
            {
                SwapPlacesX(Position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight()
        {
            if (!(Map.GetElementRight(Position) is Wall))
            {
                SwapPlacesX(Position.X + 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp()
        {
            if (!(Map.GetElementUp(Position) is Wall))
            {
                SwapPlacesY(Position.Y - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown()
        {
            if (!(Map.GetElementDown(Position) is Wall))
            {
                SwapPlacesY(Position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int x)
        {
            var value = Map.GetElement(Position);
            Map.SetElement(new Empty(Position));
            Position position = Position;
            position.X = x;
            Position = position;
            Map.SetElement(value, Position);
        }
        private void SwapPlacesY(int y)
        {
            var value = Map.GetElement(Position);
            Map.SetElement(new Empty(Position));
            Position position = Position;
            position.Y = y;
            Position = position;
            Map.SetElement(value, Position);   
        }

        public virtual char GetCharElement()
        {
            throw new System.NotImplementedException();
        }
    }
}

