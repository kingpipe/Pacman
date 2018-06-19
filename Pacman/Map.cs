using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System.IO;

namespace PacMan
{
    public class Map : IMap
    {
        public int[,] map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] OldMap { get; set; }
       
        public Map(string path,ISize size)
        {
            map = LoadMap(path, size);
            Width = map.GetLength(0);
            Height = map.GetLength(1);
            OldMap = map;
        }
        public void StartMap()
        {
            map = OldMap;
        }

        private int[,] LoadMap(string path, ISize size)
        {
            int[,] map = new int[size.Width, size.Height];
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
                            map[x, y] = Empty.GetNumberElement();
                            break;
                        case '1':
                            map[x, y] = Wall.GetNumberElement();
                            break;
                        case '2':
                            map[x, y] = LittleGoal.GetNumberElement();
                            break;
                        case '5':
                            map[x, y] = Pacman.GetNumberElement();
                            break;
                        case '7':
                            map[x, y] = Clyde.GetNumberElement();
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
