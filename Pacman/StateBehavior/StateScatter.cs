using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateScatter : IState
    {
        public void ChangeBehavior(ChangeStateGhosts changeState)
        {
            foreach (var ghost in changeState.Ghosts.Ghosts)
            {
                ghost.Strategy = new AstarAlgorithm();
            }
            changeState.State = new StateAttack();
        }
    }
}
