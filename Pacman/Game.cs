using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System.IO;


namespace PacMan
{
    public class Game:IGame
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
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void End()
        {
            throw new System.NotImplementedException();
        }

        public bool Move(Direction direction)
        {
            pacman.Move(direction, map);
            return clyde.Move(map);
        }

        public static int[,] LoadMap(string path, ISize size)
        {
            int[,] map = new int[size.Width,size.Height];
            int counter=0;
            StreamReader FileWithMap = new StreamReader(path);
            char[] array = FileWithMap.ReadToEnd().ToCharArray();
            for(int y=0;y<size.Height; y++)
            {
                for(int x=0;x<size.Width;x++)
                {
                    switch(array[counter++])
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
