using Pacman.Interfaces;

namespace PacMan.StateBehavior
{
    class StateScatter : IState
    {
        public void ChangeBehavior(Time time)
        {
            time.State = new StateAttack();
        }
    }
}
