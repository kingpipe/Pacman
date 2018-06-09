using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman:Player
    {
        public Pacman(Position position):base(position)
        {

        }
        public bool Move(Direction direction, Game game)
        {
            this.direction = direction;
            switch (this.direction)
            {
                case Direction.Left:
                    return MoveLeft(game);
                case Direction.Right:
                    return MoveRight(game);
                case Direction.Up:
                    return MoveUp(game);
                case Direction.Down:
                    return MoveDown(game);
                default:
                    return false;
            }
        }

        private bool MoveLeft(Game game)
        {
            if (game.map[position.X - 1, position.Y] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X - 1, position.Y] = (int)Elements.Pacman;
                position.X = position.X - 1;
                return true;
            }
            return false;
        }

        private bool MoveRight(Game game)
        {
            while (true)
            {
                if (game.map[position.X + 1, position.Y] != (int)Elements.Wall)
                {
                    game.map[position.X, position.Y] = (int)Elements.None;
                    game.map[position.X + 1, position.Y] = (int)Elements.Pacman;
                    position.X = position.X + 1;
                    if (this.direction == Direction.Right)
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    return true;
                }
                else
                    return false;
            }
        }

        private bool MoveUp(Game game)
        {
            if (game.map[position.X, position.Y-1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y-1] = (int)Elements.Pacman;
                position.Y = position.Y - 1;
                return true;
            }
            return false;
        }

        private bool MoveDown(Game game)
        {
            if (game.map[position.X, position.Y + 1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y+1] = (int)Elements.Pacman;
                position.Y = position.Y+1;
                return true;
            }
            return false;
        }
    }
}
