using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using PacMan.Enums;
using System.Threading.Tasks;

namespace PacMan
{
    public sealed class Game
    {
        private const int TIME = 200;
        private readonly Pacman _pacman;
        private readonly Cherry _cherry;
        private readonly MenagerGhosts _ghosts;
        private readonly Map _defaultMap;
        private GameStatus _status;
        private event Action UpdateMap;

        public Map Map{ get; private set; }
        public int Score => _pacman.Count;
        public int Lives => _pacman.Lives;
        public int Level => _pacman.Level;
        
        public Game(string path, string name)
        {
            _status = GameStatus.NeedInitEvent;
            Map = new Map(path, name);
            _defaultMap = (Map)Map.Clone();
            _pacman = Map.Pacman;
            _pacman.SetTime(TIME);
            _cherry = new Cherry(new Position(Map.Widht / 2, Map.Height / 2 + Map.Height % 2 + 1), Map);
            _ghosts = new MenagerGhosts(Map, TIME);

            _pacman.SinkAboutEatEnergizer += _ghosts.AreFrightened;
            _pacman.SinkAboutCreateCherry += () => _cherry.Start();
            _pacman.SinkAboutNextLevel += NextLevel;
            _pacman.SinkAboutEatGhost += _ghosts.EatGhost;
            _ghosts.AddSinkAboutEatPacmanHandler(PacmanIsKilled);
        }

        public void AddHandler(Action<ICoord> move, Action score, Action updatemap)
        {
            if (_status == GameStatus.NeedInitEvent)
            {
                _ghosts.AddMoveHandler(move);
                _cherry.Movement += move;
                _pacman.Movement += move;
                _pacman.SinkAboutChangeScore += score;
                UpdateMap += updatemap;
                _status = GameStatus.ReadyToStart;
            }
        }

        public void SetDirection(Direction direction)
        {
            _pacman.NewDirection = direction;
        }

        public void Start()
        {
            if (_status == GameStatus.Stop || _status == GameStatus.ReadyToStart)
            {
                _status = GameStatus.InProcess;
                _ghosts.Start();
                _pacman.Start();
            }
        }

        public void Stop()
        {
            if (_status == GameStatus.InProcess)
            {
                _status = GameStatus.Stop;
                _pacman.Stop();
                _ghosts.Stop();
                UpdateMap();
            }
        }
        public void Default()

        {
            if (_status != GameStatus.ReadyToStart && _status != GameStatus.NeedInitEvent)
            {
                if (_status != GameStatus.Stop)
                {
                    Stop();
                }
                _status = GameStatus.ReadyToStart;
                Map = (Map)_defaultMap.Clone();
                _ghosts.Default(Map);
                _pacman.Default(Map);
                _pacman.StartPosition();
                UpdateMap();
            }
        }

        private void NextLevel()
        {
            Stop();
            Map = (Map)_defaultMap.Clone();
            _pacman.StartPosition();
            _pacman.Map = Map;
            _ghosts.StartPositions();
            _ghosts.AreNotFrightened();
            _ghosts.DefaultMap(Map);
            UpdateMap();
            Start();
        }

        private async Task PacmanIsKilled()
        {
            Stop();
            _pacman.Lives--;
            _pacman.StartPosition();
            _ghosts.StartPositions();
            UpdateMap();
            if (_pacman.Lives > 0)
            {
                await Task.Delay(2000);
                if (_status != GameStatus.InProcess)
                {
                    Start();
                }
            }
            else
            {
                await Task.Delay(1000);
                Default();
                _status = GameStatus.ReadyToStart;
                UpdateMap();
            }
        }
    }
}