using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;


namespace PacMan
{
    public class Game:IGame
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
            Map.map[Clyde.Position.X, Clyde.Position.Y] = new Clyde(Clyde.Position, Map);
            Map.map[Pacman.Position.X, Pacman.Position.Y] = new Pacman(Pacman.Position, Map);
        }

        public void RemovePlayers()
        {
            Map.map[Clyde.Position.X, Clyde.Position.Y] = new Empty(Clyde.Position);
            Map.map[Pacman.Position.X, Pacman.Position.Y] = new Empty(Pacman.Position);
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
