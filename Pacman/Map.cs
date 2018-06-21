using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System.IO;

namespace PacMan
{
    public class Map : IMap
    {
        public ICoord[,] map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
       
        public Map(string path,ISize size)
        {
            map = LoadMap(path, size);
            Width = map.GetLength(0);
            Height = map.GetLength(1);
        }

        private ICoord[,] LoadMap(string path, ISize size)
        {
            ICoord[,] map = new ICoord[size.Width, size.Height];
            int counter = 0;
            StreamReader FileWithMap = new StreamReader(path);
            char[] array = FileWithMap.ReadToEnd().ToCharArray();
            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    switch (array[counter++])
                    {
                        case '0':
                            map[x, y] = new Empty(new Position(x,y));
                            break;
                        case '1':
                            map[x, y] = new Wall(new Position(x, y));
                            break;
                        case '2':
                            map[x, y] = new LittleGoal(new Position(x, y));
                            break;
                        case '3':
                            map[x, y] = new BigGoal(new Position(x, y));
                            break;
                        case '5':
                            map[x, y] = new Pacman(new Position(x, y), map);
                            break;
                        case '7':
                            map[x, y] = new Clyde(new Position(x, y), map);
                            break;
                        default:
                            continue;
                    }
                }
                counter += 2;
            }
            return map;
        }
    }
}
