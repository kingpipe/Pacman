using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;


namespace PacMan
{
    public class Game : IGame
    {
        public Map Map { get; set; }
        public Pacman Pacman { get; private set; }
        public Clyde Clyde { get; private set; }

        public Game(string path, ISize size)
        {
            Map = new Map(path, size);
            Pacman = new Pacman(Map);
            Clyde = new Clyde(Map);
        }
        public bool Move(Direction direction)
        {
            return Pacman.Move(direction);
        }
        public void Start()
        {
            RemovePlayers();
            Pacman.StartPosition();
            Clyde.StartPosition();
            CreatePlayers();
        }

        private void CreatePlayers()
        {
            Map.SetElement(new Clyde(Map));
            Map.SetElement(new Pacman(Map));
        }

        public void RemovePlayers()
        {
            Map.SetElement(new Empty(Clyde.Position));
            Map.SetElement(new Empty(Pacman.Position));
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void End()
        {
            throw new System.NotImplementedException();
        }

    }
}
