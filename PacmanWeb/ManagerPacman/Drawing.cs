using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.ManagerPacman
{
    public class Drawing
    {
        private Game Game { get; }
        private PacmanHub PacmanHub { get; }

        public Drawing(PacmanHub hub)
        {
           // Game = hub.Game;
            PacmanHub = hub;
        }

        public void ShowMap()
        {
            ICoord[,] array = Game.Map.map;
            for (int y = 0; y < Game.Map.Height; y++)
            {
                for (int x = 0; x < Game.Map.Width; x++)
                {
                 //   PacmanHub.HandlerToPlayers(array[x, y]);
                }
            }
        }
    }
}