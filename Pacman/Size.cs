using PacMan.Interfaces;

namespace PacMan
{
    public class Size : ISize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
