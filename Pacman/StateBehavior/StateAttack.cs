using PacMan.Algorithms;
using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateAttack : IState
    {
        public void ChangeBehavior(MenagerGhosts ghosts)
        {
            foreach (var ghost in ghosts.Ghosts)
            {
                ghost.Strategy = new RandomMoving();
            }
            ghosts.State = new StateScatter();
        }
    }
}
