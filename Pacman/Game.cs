using System.IO;

namespace Pacman
{
    public class Game
    {
        private Pacman pacman;
        public int[,] map;
        public Game(int pacmanX, int pacmanY, int[,] map)
        {
            pacman = new Pacman(new Position(pacmanX, pacmanY));
            this.map = map;
        }

        public void PacmanMove(Direction direction)
        {
            switch (direction)
                {
                    case Direction.Left:
                        pacman.MoveLeft(this);
                        break;
                    case Direction.Right:
                        pacman.MoveRight(this);
                        break;
                    case Direction.Up:
                        pacman.MoveUp(this);
                        break;
                    case Direction.Down:
                        pacman.MoveDown(this);
                        break;
                    default:
                        break;
                }
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
