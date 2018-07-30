namespace PacMan.Interfaces
{
    interface IState
    {
        void ChangeBehavior(ChangeStateGhosts changeState);
    }
}
