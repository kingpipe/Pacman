using System.Collections.Generic;
using PacMan;
using PacmanWeb.Hubs;

namespace PacmanWeb.Models
{
    public class GameCollection
    {
        private readonly Dictionary<string, ConnectionGame> games;

        public GameCollection()
        {
            games = new Dictionary<string, ConnectionGame>();
        }

        public void AddGame(string key, ConnectionGame connectiongame)
        {
            games.Add(key, connectiongame);
        }

        public void RemoveGame(string key)
        {
            games.Remove(key);
        }

        public Game this[string key] => games[key].Game;
    }
}
