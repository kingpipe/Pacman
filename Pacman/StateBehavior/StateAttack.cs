using PacMan.Algorithms;
using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateAttack : IState
    {
        public void ChangeBehavior(ChangeStateGhosts changeState)
        {
            foreach (var ghost in changeState.Ghosts.Ghosts)
            {
                ghost.Strategy = new RandomMoving();
            }
            changeState.State = new StateScatter();
        }
    }
}
