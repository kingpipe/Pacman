using System.IO;
using System.Threading;

namespace Pacman
{
    public class Game
    {
        private Pacman pacman;
        private Clyde clyde;
        public int[,] map;
        public Game(int pacmanX, int pacmanY, int clydeX, int clydeY, int[,] map)
        {
            clyde = new Clyde(new Position(clydeX, clydeY));
            pacman = new Pacman(new Position(pacmanX, pacmanY));
            this.map = map;
        }

        public bool PacmanMove(Direction direction)
        {
            return pacman.Move(direction, this);
        }
        public bool ClydeMove()
        {
            return clyde.Move(this);
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
