using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using System.Timers;

namespace PacMan
{
    public class Game : IGame, IDisposable
    {
        private const int TIME = 500;
        private Timer Timer { get; set; }
        public bool PacmanIsLive { get; set; }
        public Map Map { get; set; }
        public Pacman Pacman { get; private set; }
        public ColectionGhosts Ghosts { get; private set; }
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
            Timer = new Timer(TIME);
            Pacman = new Pacman(Map);
            Ghosts = new ColectionGhosts(Map);
        }

        public bool Move(Direction direction)
        {
            return Pacman.Move(direction);
        }

        public void PacmanIsDied()
        {
            Pacman.Stop(Timer);
            Ghosts.StopTimer(Timer);
            Ghosts.RemoveSinkAboutEatPacmanHandler(PacmanIsKilled);
            Pacman.Lives--;
            RemovePlayers();
            Pacman.StartPosition();
            Ghosts.StartPosition();
            CreatePlayers();
            PacmanIsLive = true;
        }

        public void Start()
        {
            Ghosts.AddSinkAboutEatPacmanHandler(PacmanIsKilled);
            Ghosts.StartTimer(Timer);
            Pacman.Start(Timer);
        }

        private void CreatePlayers()
        {
            Map.SetElement(new Pacman(Map));
            Ghosts.SetGhosts();
        }

        private void RemovePlayers()
        {
            Map.SetElement(new Empty(Pacman.Position));
            Ghosts.RemoveGhosts();
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
