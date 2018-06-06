using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Player
    {
        public Position position { get; private set; }
        public int[,] map;
        public Player(Position position)
        {
            this.position = position;
            map = InitMap();
        }

        private int[,] InitMap()
        {
            map = new int[16, 16];
            for(int x=0; x<16;x++)
                for(int y=0; y<16;y++)
                {
                    map[x, y] = (int)Elements.None;
                }
            map[position.X, position.Y] = (int)Elements.Pacman;
            return map;
        }
        
        public bool CanMoveLeft(int[,] map)
        {
            if(position.OnMap())
            {
                map[position.X, position.Y] = (int)Elements.None;
                map[position.XminusOne, position.Y] = (int)Elements.Pacman;
                position.X=position.XminusOne;
            }
            return false;
        }
        public bool CanMoveRight()
        {
            if (position.OnMap())
            {
                map[position.X, position.Y] = (int)Elements.None;
                map[position.XplusOne, position.Y] = (int)Elements.Pacman;
                position.X = position.XplusOne;
            }
            return false;
        }
        public bool CanMoveDown()
        {
            if (position.OnMap())
            {
                map[position.X, position.Y] = (int)Elements.None;
                map[position.X, position.YminusOne] = (int)Elements.Pacman;
                Y--;
            }
            return false;
        }
        public bool CanMoveUp()
        {
            if (position.OnMap())
            {
                map[position.X, position.Y] = (int)Elements.None;
                map[position.X, position.YplusOne] = (int)Elements.Pacman;
                Y++;
            }
            return false;
        }

    }
}
