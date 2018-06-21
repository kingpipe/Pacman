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
            map = new Map(path, size);
            pacman = new Pacman(map.map);
            clyde = new Clyde(map.map);
        }
        public bool Move(Direction direction)
        {
            return pacman.Move(direction);
        }
        public void Start()
        {
            RemovePlayers();
            pacman.StartPosition();
            clyde.StartPosition();
            CreatePlayers();
        }

        private void CreatePlayers()
        {
            map.map[clyde.position.X, clyde.position.Y] = new Clyde(clyde.position, map.map);
            map.map[pacman.position.X, pacman.position.Y] = new Pacman(pacman.position, map.map);
        }

        public void RemovePlayers()
        {
            map.map[clyde.position.X, clyde.position.Y] = new Empty(clyde.position);
            map.map[pacman.position.X, pacman.position.Y] = new Empty(pacman.position);
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
