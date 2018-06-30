using Pacman.Interfaces;

namespace PacMan.StateBehavior
{
    class StateAttack : IState
    {
        public void ChangeBehavior(Time time)
        {
            time.State = new StateScatter();
        }
    }
}
