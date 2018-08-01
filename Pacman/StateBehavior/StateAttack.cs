using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateAttack : IState
    {
        public void ChangeBehavior(ChangeStateGhosts changeState)
        {
            changeState.Ghosts.SetStrategyRandom();
            changeState.State = new StateScatter();
        }
    }
}
