using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;

namespace PacMan
{
    public class Game : IGame, IDisposable
    {
        public bool PacmanIsLive { get; set; }
        public Map Map { get; set; }
        public Pacman Pacman { get; private set; }
        public Clyde Clyde { get; private set; }
        public int Score
        {
            get
            {
                return Pacman.Count;
            }
        }
        public int Lives
        {
            get
            {
                return Pacman.Lives;
            }
        }

        public Game(string path, ISize size)
        {
            PacmanIsLive = true;
            Map = new Map(path, size);
            Pacman = new Pacman(Map);
            Clyde = new Clyde(Map);
        }
        public bool Move(Direction direction)
        {
            return Pacman.Move(direction);
        }
        public void PacmanIsDied()
        {
            Clyde.SinkAboutEatPacman -= PacmanIsKilled;
            Pacman.Lives--;
            RemovePlayers();
            Pacman.StartPosition();
            Clyde.StartPosition();
            CreatePlayers();
            PacmanIsLive = true;
        }

        public async void Start()
        {
            Clyde.SinkAboutEatPacman += PacmanIsKilled;
            await Clyde.StartAsync(250);
        }

        private void CreatePlayers()
        {
            Map.SetElement(new Clyde(Map));
            Map.SetElement(new Pacman(Map));
        }

        private void RemovePlayers()
        {
            Map.SetElement(new Empty(Clyde.Position));
            Map.SetElement(new Empty(Pacman.Position));
        }

        public void Stop()
        {

        }

        public void End()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        private void PacmanIsKilled()
        {
            PacmanIsLive = false;
        }
    }
}
