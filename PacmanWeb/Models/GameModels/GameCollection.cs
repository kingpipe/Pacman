using System.Collections.Generic;
using PacMan;

namespace PacmanWeb.Models.GameModels
{
    public class GameCollection
    {
        private readonly Dictionary<string, GameConnection> _games;

        public GameCollection()
        {
            _games = new Dictionary<string, GameConnection>();
        }

        public void AddGame(string key, GameConnection connectiongame)
        {
            _games.Add(key, connectiongame);
        }

        public void RemoveGame(string key)
        {
            _games.Remove(key);
        }

        public Game this[string key] => _games[key].Game;
    }
}
