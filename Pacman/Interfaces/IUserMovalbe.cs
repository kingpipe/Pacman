namespace PacMan.Interfaces
{
    interface IUserMovalbe: IMovable
    {
        bool Move(Direction direction);
    }
}
