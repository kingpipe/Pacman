using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using System.Timers;

namespace PacMan
{
    public class Game : IGame
    {
        private const int TIME = 500;
        private Timer Timer { get; set; }
        private Pacman Pacman { get; set; }
        private ColectionGhosts Ghosts { get; set; }

        public bool PacmanIsLive { get; set; }
        public Map Map { get; set; }
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

        public void AddMoveHandlerToGhosts(Action<ICoord> action)
        {
            Ghosts.AddMoveHandler(action);
        }

        public void AddMoveHandlerToPacman(Action<ICoord> action)
        {
            Pacman.Movement += action;
        }

        public void SetDirection(Direction direction)
        {
            Pacman.direction = direction;
        }

        public void Start()
        {
            Ghosts.AddSinkAboutEatPacmanHandler(PacmanIsKilled);
            Ghosts.StartTimer(Timer);
            Pacman.Start(Timer);
        }

        public void Stop()
        {
            Pacman.direction = Direction.None;
            Pacman.Stop(Timer);
            Ghosts.StopTimer(Timer);
            Ghosts.RemoveSinkAboutEatPacmanHandler(PacmanIsKilled);

            if (PacmanIsLive == false)
            {
                Pacman.Lives--;
                PacmanIsLive = true;
                RemovePlayers();
                Pacman.StartPosition();
                Ghosts.StartPosition();
                CreatePlayers();
            }
        }

        public void End()
        {
            GC.SuppressFinalize(true);
        }

        private void PacmanIsKilled()
        {
            PacmanIsLive = false;
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
    }
}
