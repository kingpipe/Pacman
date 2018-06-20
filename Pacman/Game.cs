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
            pacman = new Pacman();
            clyde = new Clyde();
            map = new Map(path, size);
        }
        public bool Move(Direction direction)
        {
            pacman.Move(direction, map.map);
            return clyde.Move(map.map);
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
            map.map[clyde.position.X, clyde.position.Y] = new Clyde(clyde.position);
            map.map[pacman.position.X, pacman.position.Y] = new Pacman(pacman.position);
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
