using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;

namespace PacMan
{
    public sealed class Game : IGame, IDisposable
    {
        private const int TIME = 400;
        private const int TIMEFORPACMAN = 150;
        private Pacman Pacman { get; set; }
        private Cherry Cherry { get; set; }
        private MenegerGhosts Ghosts { get; set; }
        private Map DefaultMap { get; set; }

        public event Action PacmanIsDied;
        public event Action UpdateMap;
        public bool PacmanIsLive { get; private set; }
        public Map Map { get; private set; }
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
        public int Level
        {
            get
            {
                return Pacman.Level;
            }
        }

        public Game(string path, ISize size)
        {
            PacmanIsLive = true;
            Map = new Map(path, size);
            DefaultMap = (Map)Map.Clone();
            Pacman = new Pacman(Map, TIMEFORPACMAN);
            Cherry = new Cherry(new Position(14, 17), Map);
            Ghosts = new MenegerGhosts(Map, TIME);

            Pacman.SinkAboutEatEnergizer += Ghosts.GhostsAreFrightened;
            Pacman.SinkAboutCreateCherry += () => Cherry.Start();
            Pacman.SinkAboutNextLevel += Pacman_SinkAboutNextLevel;
        }

        private void Pacman_SinkAboutNextLevel()
        {
            SetDirection(Direction.None);
            RemovePlayers();
            Map = (Map)DefaultMap.Clone();
            Pacman.Map = Map;
            Ghosts.SetDefaultMap(Map);
            UpdateMap();
            Pacman.StartPosition();
            Ghosts.StartPosition();
            CreatePlayers();
        }

        public void AddMoveHandlerToGhosts(Action<ICoord> action)
        {
            Ghosts.AddMoveHandler(action);
            Cherry.Movement += action;
        }

        public void AddMoveHandlerToPacman(Action<ICoord> action)
        {
            Pacman.Movement += action;
        }

        public void SetDirection(Direction direction)
        {
            Pacman.Direction = direction;
        }

        public void Start()
        {
            Ghosts.AddSinkAboutEatPacmanHandler(PacmanIsKilled);
            Ghosts.StartTimer();
            Pacman.Start();
        }

        public void Stop()
        {
            Pacman.Direction = Direction.None;
            Pacman.Stop();
            Ghosts.StopTimer();
            Ghosts.RemoveSinkAboutEatPacmanHandler(PacmanIsKilled);
            if (!PacmanIsLive)
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
            Dispose();
        }

        private void PacmanIsKilled()
        {
            PacmanIsLive = false;
            PacmanIsDied();
        }

        private void CreatePlayers()
        {
            Map.SetElement(Pacman);
            Ghosts.SetGhosts();
        }

        private void RemovePlayers()
        {
            Map.SetElement(new Empty(Pacman.Position));
            Ghosts.RemoveGhosts();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}