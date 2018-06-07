using System.IO;

namespace Pacman
{
    public class Game
    {
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
