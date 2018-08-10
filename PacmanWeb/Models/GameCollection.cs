using System.Collections.Generic;
using PacMan;
using PacmanWeb.Hubs;

namespace PacmanWeb.Models
{
    public class GameCollection
    {
        private readonly Dictionary<string, GameAndContext> games;

        public GameCollection()
        {
            games = new Dictionary<string, GameAndContext>();
        }

        public void AddGame(string key, GameAndContext gac)
        {
            if (games.ContainsKey(key))
            {
                games[key] = gac;
            }
            else
            {
                games.Add(key, gac);
            }
        }

        public void RemoveGame(string key)
        {
            games.Remove(key);
        }

        public Game this[string key]
        {
            get => games[key].game;
        }
    }
}
