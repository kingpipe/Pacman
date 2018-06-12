namespace Pacman
{
    public enum Elements
    {
        None,
        Wall,
        Pacman,
        Clyde
    }
    public static class ExpendElements
    {
        public static char GetChar(this Elements elements)
        {
            if (elements == Elements.None)
                return (char)183;
            if (elements == Elements.Wall)
                return '#';
            if (elements == Elements.Pacman)
                return 'P';
            if (elements == Elements.Clyde)
                return 'C';
            return ' ';
        }
    }
}
