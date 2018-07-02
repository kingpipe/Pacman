using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateScatter : IState
    {
        public void ChangeBehavior(ColectionGhosts ghosts)
        {
            foreach (var ghost in ghosts.Ghosts)
            {
                ghost.strategy = new AstarAlgorithm();
            }
            ghosts.State = new StateAttack();
        }
    }
}
