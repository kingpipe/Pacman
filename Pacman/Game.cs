using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using PacMan.Enums;

namespace PacMan
{
    public sealed class Game : IDisposable
    {
        private const int TIME = 200;
        private const int TIMEFORPACMAN = 200;
        private Pacman Pacman { get; set; }
        private Cherry Cherry { get; set; }
        private MenagerGhosts Ghosts { get; set; }
        private Map DefaultMap { get; set; }

        public event Action PacmanIsDied;
        public event Action UpdateMap;
        public bool PacmanIsLive { get; private set; }
        public GameStatus Status { get; private set; }
        public Map Map { get; private set; }
        public int Score => Pacman.Count;
        public Direction Direction => Pacman.Direction;
        public int Lives => Pacman.Lives;
        public int Level => Pacman.Level;

        public Game(string path)
        {
            Status = GameStatus.NeedInitEvent;
            PacmanIsLive = true;
            Map = new Map(path, "BlueMap");
            DefaultMap = (Map)Map.Clone();
            Pacman = Map.Pacman;
            Pacman.SetTime(TIMEFORPACMAN);
            Cherry = new Cherry(new Position(Map.Width / 2, Map.Height / 2 + Map.Height % 2 + 2), Map);
            Ghosts = new MenagerGhosts(Map, TIME);

            Pacman.SinkAboutEatEnergizer += Ghosts.AreFrightened;
            Pacman.SinkAboutCreateCherry += () => Cherry.Start();
            Pacman.SinkAboutNextLevel += Pacman_SinkAboutNextLevel;
            Pacman.SinkAboutEatGhost += Ghosts.EatGhost;
            Ghosts.AddSinkAboutEatPacmanHandler(PacmanIsKilled);
        }

        public void SetMap(string path, string name)
        {
            Map = new Map(path, name);
            DefaultMap = (Map)Map.Clone();
            Pacman.Map = Map;
            Pacman.StartCoord = Map.Pacman.StartCoord;
            Ghosts.SetDefaultMap(Map);
            Ghosts.SetStartCoord(Map);
            Cherry.Position = new Position(Map.Width / 2, Map.Height / 2 + Map.Height % 2 + 1);
        }

        public void Default()
        {
            Status = GameStatus.ReadyToStart;
            Map = (Map)DefaultMap.Clone();
            Ghosts.Default(Map);
            Pacman.Default(Map);
        }

        private void Pacman_SinkAboutNextLevel()
        {
            Stop();
            RemovePlayers();
            Map = (Map)DefaultMap.Clone();
            Pacman.Map = Map;
            Ghosts.SetDefaultMap(Map);
            Ghosts.ArenotFrightened();
            UpdateMap();
            CreatePlayers();
        }

        public void AddHandler(Action<ICoord> ghost, Action<ICoord> pacman, Action updatemap, Action pacmandied)
        {
            Ghosts.AddMoveHandler(ghost);
            Cherry.Movement += ghost;

            Pacman.Movement += pacman;

            UpdateMap += updatemap;

            PacmanIsDied += pacmandied;

            Status = GameStatus.ReadyToStart;
        }

        public void SetDirection(Direction direction)
        {
            Pacman.NewDirection = direction;
        }

        public void Start()
        {
            Status = GameStatus.InProcess;
            Ghosts.Start();
            Pacman.Start();
        }

        public void Stop()
        {
            if (Status != GameStatus.TheEnd && Status != GameStatus.Stop)
            {
                Status = GameStatus.Stop;
                Pacman.Direction = Direction.None;
                Pacman.Stop();
                Ghosts.Stop();
                if (!PacmanIsLive)
                {
                    Pacman.Lives--;
                    if (Pacman.Lives > 0)
                    {
                        PacmanIsLive = true;
                        CreatePlayers();
                    }
                    else
                    {
                        Status = GameStatus.TheEnd;
                    }
                }
            }
        }

        public void End()
        {
            Status = GameStatus.TheEnd;
            Dispose();
        }

        private void PacmanIsKilled()
        {
            RemovePlayers();
            PacmanIsLive = false;
            PacmanIsDied();
        }

        private void CreatePlayers()
        {
            Pacman.SetOnMap();
            Ghosts.SetGhosts();
        }

        private void RemovePlayers()
        {
            Pacman.RemoveFromMap();
            Ghosts.RemoveGhosts();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}