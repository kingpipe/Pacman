using PacMan.Interfaces;
using PacMan.Players;
using PacMan.Foods;
using System;
using System.Timers;

namespace PacMan
{
    public class Game : IGame, IDisposable
    {
        public bool PacmanIsLive { get; set; }
        public Map Map { get; set; }
        public Pacman Pacman { get; private set; }
        public Blinky Blinky { get; private set; }
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
        public Timer ClydeTimer { get; set; }

        public Game(string path, ISize size)
        {
            ClydeTimer = new Timer(500);
            PacmanIsLive = true;
            Map = new Map(path, size);
            Pacman = new Pacman(Map);
            Blinky = new Blinky(Map);
            Clyde = new Clyde(Map);
        }
        public bool Move(Direction direction)
        {
            return Pacman.Move(direction);
        }
        public void PacmanIsDied()
        {
            Blinky.SinkAboutEatPacman -= PacmanIsKilled;
            Clyde.SinkAboutEatPacman -= PacmanIsKilled;
            Pacman.Lives--;
            RemovePlayers();
            Pacman.StartPosition();
            Blinky.StartPosition();
            Clyde.StartPosition();
            CreatePlayers();
            PacmanIsLive = true;
        }

        public async void Start()
        {
            Blinky.SinkAboutEatPacman += PacmanIsKilled;
            Clyde.SinkAboutEatPacman += PacmanIsKilled;
            Clyde.StartAsync(500);
            await Blinky.StartAsync(500);
        }

        private void CreatePlayers()
        {
            Map.SetElement(new Blinky(Map));
            Map.SetElement(new Pacman(Map));
            Map.SetElement(new Clyde(Map));
        }

        private void RemovePlayers()
        {
            Map.SetElement(new Empty(Clyde.Position));
            Map.SetElement(new Empty(Blinky.Position));
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
