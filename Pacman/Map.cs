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
        internal Pacman Pacman { get; private set; }
        internal Inky Inky { get; private set; }
        internal Pinky Pinky { get; private set; }
        internal Blinky Blinky { get; private set; }
        internal Clyde Clyde { get; private set; }

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

        public ICoord this[IPosition index]
        {
            get
            {
                return map[index.X, index.Y];
            }
            set
            {
                map[index.X, index.Y] = value;
            }
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
                            Pacman = new Pacman(this, new Position(x, y));
                            maze[x, y] = Pacman;
                            break;
                        case "clyde":
                            Clyde = new Clyde(this, new Position(x, y));
                            maze[x, y] = Clyde;
                            break;
                        case "blinky":
                            Blinky = new Blinky(this, new Position(x, y));
                            maze[x, y] = Blinky;
                            break;
                        case "inky":
                            Inky = new Inky(this, new Position(x, y));
                            maze[x, y] = Inky;
                            break;
                        case "pinky":
                            Pinky = new Pinky(this, new Position(x, y));
                            maze[x, y] = Pinky;
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