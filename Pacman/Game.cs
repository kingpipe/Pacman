using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;


namespace PacMan
{
    public class Game:IGame
    {
        public Map map { get; set; }
        public Pacman pacman { get; private set; }
        public Clyde clyde { get; private set; }

        public Game(string path, ISize size)
        {
            clyde = new Clyde();
            pacman = new Pacman();
            map = new Map(path, size);
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
            pacman.Move(direction, map.map);
            return clyde.Move(map.map);
        }
    }
}
