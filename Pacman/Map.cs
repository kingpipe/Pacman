using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.IO;

namespace PacMan
{
    public class Map : IMap, ICloneable
    {
        public ICoord[,] map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(string path, ISize size)
        {
            map = LoadMap(path, size);
            Width = map.GetLength(0);
            Height = map.GetLength(1);
        }

        public object Clone()
        {
            Map board = (Map)MemberwiseClone();
            board.map = (ICoord[,])map.Clone();
            return board;
        }
        
        public ICoord GetElement(IPosition position)
        {
            return map[position.X, position.Y];
        }

        public ICoord GetElementLeft(IPosition position)
        {
            return map[position.X - 1, position.Y];
        }

        public ICoord GetElementRight(IPosition position)
        {
            return map[position.X + 1, position.Y];
        }

        public ICoord GetElementUp(IPosition position)
        {
            return map[position.X, position.Y - 1];
        }

        public ICoord GetElementDown(IPosition position)
        {
            return map[position.X, position.Y + 1];
        }

        public void SetElement(ICoord coord)
        {
            map[coord.Position.X, coord.Position.Y] = coord;
        }

        public void SetElement(ICoord coord, Position position)
        {
            coord.Position = position;
            map[position.X, position.Y] = coord;
        }

        private ICoord[,] LoadMap(string path, ISize size)
        {
            ICoord[,] maze = new ICoord[size.Width, size.Height];
            int counter = 0;
            StreamReader FileWithMap = new StreamReader(path);
            char[] array = FileWithMap.ReadToEnd().ToCharArray();
            FileWithMap.Close();
            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    switch (array[counter++])
                    {
                        case '0':
                            maze[x, y] = new Empty(new Position(x, y));
                            break;
                        case '1':
                            maze[x, y] = new Wall(new Position(x, y));
                            break;
                        case '2':
                            maze[x, y] = new LittleGoal(new Position(x, y));
                            break;
                        case '3':
                            maze[x, y] = new Energizer(new Position(x, y));
                            break;
                        case '4':
                            maze[x, y] = new Cherry(new Position(x, y), this);
                            break;
                        case '5':
                            maze[x, y] = new Pacman(this, 100);
                            break;
                        case '6':
                            maze[x, y] = new Clyde(this, 100);
                            break;
                        case '7':
                            maze[x, y] = new Blinky(this, 100);
                            break;
                        case '8':
                            maze[x, y] = new Inky(this, 100);
                            break;
                        case '9':
                            maze[x, y] = new Pinky(this, 100);
                            break;
                        default:
                            continue;
                    }
                }
                counter += 2;
            }
            return maze;
        }
    }
}