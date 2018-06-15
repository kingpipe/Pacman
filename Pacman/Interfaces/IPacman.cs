namespace PacMan.Interfaces
{
    public interface IPacman: IEateble 
    {
        int Lives { get; set; }

        //IPosition position { get; set; }


    }
}
