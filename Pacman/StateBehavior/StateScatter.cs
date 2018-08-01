using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateScatter : IState
    {
        public void ChangeBehavior(ChangeStateGhosts changeState)
        {
            changeState.Ghosts.SetStrategyRunForPacman();
            changeState.State = new StateAttack();
        }
    }
}
