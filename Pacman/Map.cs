using Newtonsoft.Json;
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
        public string Name { get; private set; }

        public Map(string path, string name)
        {
            Name = name;
            map = LoadMap(path);
            Width = map.GetLength(0);
            Height = map.GetLength(1);
        }

        public object Clone()
        {
            Map board = (Map)MemberwiseClone();
            board.map = (ICoord[,])map.Clone();
            return board;
        }

        public string[,] GetArrayID()
        {
            string[,] array = new string[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    array[x, y] = map[x, y].GetId();
                }
            }
            return array;
        }

        public bool OnMap(IPosition position)
        {
            return position.X >= 0 && position.X < Width &&
                position.Y >= 0 && position.Y < Height;
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

        private ICoord[,] LoadMap(string path)
        {
            StreamReader FileWithMap = new StreamReader(path);
            string all = FileWithMap.ReadToEnd();
            FileWithMap.Close();
            var array = JsonConvert.DeserializeObject<string[,]>(all);

            ICoord[,] maze = new ICoord[array.GetLength(1), array.GetLength(0)];

            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    switch (array[y, x])
                    {
                        case "emtry":
                            maze[x, y] = new Empty(new Position(x, y));
                            break;
                        case "wall":
                            maze[x, y] = new Wall(new Position(x, y));
                            break;
                        case "littlegoal":
                            maze[x, y] = new LittleGoal(new Position(x, y));
                            break;
                        case "energaizer":
                            maze[x, y] = new Energizer(new Position(x, y));
                            break;
                        case "cherry":
                            maze[x, y] = new Cherry(new Position(x, y), this);
                            break;
                        case "pacman":
                            maze[x, y] = new Pacman(this, 100);
                            break;
                        case "clyde":
                            maze[x, y] = new Clyde(this, 100);
                            break;
                        case "blinky":
                            maze[x, y] = new Blinky(this, 100);
                            break;
                        case "inky":
                            maze[x, y] = new Inky(this, 100);
                            break;
                        case "pinky":
                            maze[x, y] = new Pinky(this, 100);
                            break;
                        default:
                            continue;
                    }
                }
            }
            return maze;
        }
    }
}