using PacMan.Interfaces;

namespace PacMan.StateBehavior
{
    class StateAttack : IState
    {
        public void ChangeBehavior(ChangeStateGhosts changeState)
        {
            changeState.Ghosts.SetStrategyGoToCorner();
            changeState.State = new StateScatter();
        }
    }
}
