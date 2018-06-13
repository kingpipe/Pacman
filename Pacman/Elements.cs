namespace Pacman
{
    public enum Elements
    {
        None,
        Wall,
        LittleGoal,
        Apples,
        Pacman,
        Clyde,
        Blinky
    }
    public static class ExpendElements
    {
        public static char GetChar(this Elements elements)
        {
            if (elements == Elements.None)
                return ' ';
            if (elements == Elements.Wall)
                return '#';
            if (elements == Elements.Pacman)
                return 'P';
            if (elements == Elements.Clyde)
                return 'C';
            if (elements == Elements.LittleGoal)
                return (char)183;
            if (elements == Elements.Blinky)
                return 'B';
            return ' ';
        }
    }
}
