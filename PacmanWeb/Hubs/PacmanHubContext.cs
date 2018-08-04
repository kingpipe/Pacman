using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Enums;
using PacMan.Interfaces;

namespace PacmanWeb.Hubs
{
    public class PacmanHubContext
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private Game game;

        public PacmanHubContext(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
        }

        public void Game_PacmanIsDied()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Live", game.Lives));
        }

        public void UpdateMap()
        {
            hubContext.Clients.All.SendAsync("DrawMap", game.Map.GetArrayID());
            hubContext.Clients.All.SendAsync("Level", game.Level);
        }

        public void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        public void PacmanMove(ICoord coord)
        {
            string direction = string.Empty;
            if (coord.GetId() == "pacman")
            {
                direction = SetDirection(direction);
            }
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanMove",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId() + direction,
                game.Score));
        }

        public void UpdateLive()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Live", game.Lives));
        }

        private string SetDirection(string direction)
        {
            switch (game.Direction)
            {
                case Direction.Right:
                    direction = "right";
                    break;
                case Direction.Left:
                    direction = "left";
                    break;
                case Direction.Up:
                    direction = "up";
                    break;
                case Direction.Down:
                    direction = "down";
                    break;
                default:
                    break;
            }
            return direction;
        }

    }
}
