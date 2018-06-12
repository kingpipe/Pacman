using System.IO;
using System.Threading;

namespace Pacman
{
    public class Game
    {
         public int[,] map;

        public Pacman pacman { get; private set; }
        public Clyde clyde { get; private set; }

        public Game(int[,] map)
        {
            clyde = new Clyde();
            pacman = new Pacman();
            this.map = map;
        }
        public bool PacmanMove(Direction direction)
        {
            return pacman.Move(direction, map);
        }
        public bool ClydeMove()
        {
            return clyde.Move(map);
        }

        public static int[,] LoadMap(string path, int width, int height)
        {
            int[,] map = new int[width,height];
            int counter=0;
            StreamReader FileWithMap = new StreamReader(path);
            char[] array = FileWithMap.ReadToEnd().ToCharArray();
            for(int y=0;y<height; y++)
            {
                for(int x=0;x<width;x++)
                {
                    switch(array[counter++])
                    {
                        case '0':
                            map[x, y] = (int)Elements.None;
                            break;
                        case '1':
                            map[x, y] = (int)Elements.Wall;
                            break;
                        case '2':
                            map[x, y] = (int)Elements.Pacman;
                            break;
                        case '3':
                            map[x, y] = (int)Elements.Clyde;
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
