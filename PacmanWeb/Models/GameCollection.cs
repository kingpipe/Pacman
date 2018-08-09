using System.Collections.Generic;
using PacMan;

namespace PacmanWeb.Models
{
    public class GameCollection
    {
        private readonly Dictionary<string, Game> games;

        public GameCollection()
        {
            games = new Dictionary<string, Game>();
        }

        public void AddGame(string key, Game game)
        {
            games.Add(key, game);
        }

        public void RemoveGame(string key)
        {
            games.Remove(key);
        }

        public Game this[string key]
        {
            get => games[key];
        }
    }
}
