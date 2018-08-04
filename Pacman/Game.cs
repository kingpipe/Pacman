using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using PacMan.Enums;
using System.Threading.Tasks;

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
        public GameStatus Status { get; private set; }
        public Map Map { get; private set; }
        public int Score => Pacman.Count;
        public Direction Direction => Pacman.Direction;
        public int Lives => Pacman.Lives;
        public int Level => Pacman.Level;

        public Game(string path)
        {
            Status = GameStatus.NeedInitEvent;
            Map = new Map(path, "BlueMap");
            DefaultMap = (Map)Map.Clone();
            Pacman = Map.Pacman;
            Pacman.SetTime(TIMEFORPACMAN);
            Cherry = new Cherry(new Position(Map.Widht / 2, Map.Height / 2 + Map.Height % 2 + 2), Map);
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
            Cherry.Position = new Position(Map.Widht / 2, Map.Height / 2 + Map.Height % 2 + 1);
        }

        public void Default()
        {
            if (Status != GameStatus.ReadyToStart && Status != GameStatus.NeedInitEvent)
            {
                if (Status != GameStatus.Stop)
                {
                    Stop();
                }
                Status = GameStatus.ReadyToStart;
                Map = (Map)DefaultMap.Clone();
                Ghosts.Default(Map);
                Pacman.Default(Map);
                Pacman.DefaultCoord();
            }
        }

        private void Pacman_SinkAboutNextLevel()
        {
            Stop();
            Map = (Map)DefaultMap.Clone();
            Pacman.Map = Map;
            Ghosts.SetDefaultMap(Map);
            Ghosts.ArenotFrightened();
            DefaultPositions();
            UpdateMap();
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
            if (Status == GameStatus.Stop || Status == GameStatus.ReadyToStart)
            {
                Status = GameStatus.InProcess;
                Ghosts.Start();
                Pacman.Start();
            }
        }

        public void Stop()
        {
            if (Status == GameStatus.InProcess)
            {
                Status = GameStatus.Stop;
                Pacman.Stop();
                Ghosts.Stop();
            }
        }

        public void End()
        {
            Status = GameStatus.TheEnd;
            Dispose();
        }

        private void DefaultPositions()
        {
            Pacman.StartPosition();
            Ghosts.StartPositions();
        }

        private async Task PacmanIsKilled()
        {
            Stop();
            Pacman.Lives--;
            PacmanIsDied();
            if (Pacman.Lives > 0)
            {
                DefaultPositions();
                await Task.Delay(3000);
                if (Status != GameStatus.InProcess)
                {
                    Start();
                }
            }
            else
            {
                Status = GameStatus.TheEnd;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}