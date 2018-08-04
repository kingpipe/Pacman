using System.Collections.Generic;
using PacMan;

namespace PacmanWeb.Hubs
{
    public class ConnectionMapping
    {
        private readonly Dictionary<string, Game> _connections =
          new Dictionary<string, Game>();

        public Game this[string key] => _connections[key];

        public void Add(string key)
        {
            lock (_connections)
            {
                if (!_connections.ContainsKey(key))
                {
                    _connections.Add(key, new Game(""));
                }
            }
        }
        public void Remove(string key)
        {
            lock (_connections)
            {
                if (_connections.ContainsKey(key))
                {
                    _connections.Remove(key);
                }
            }
        }
    }
}
