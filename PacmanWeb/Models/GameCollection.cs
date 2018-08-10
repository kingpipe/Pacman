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

        public void AddGame(string key, ConnectionGame gac)
        {
            games.Add(key, gac);
        }

        public void RemoveGame(string key)
        {
            games.Remove(key);
        }

        public Game this[string key]
        {
            get => games[key].Game;
        }
    }
}
