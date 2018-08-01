using PacMan.Abstracts;

namespace PacMan.Foods
{
    class Energizer : Food
    {
        public Energizer(Position position) : base(position)
        {
            id = "energaizer";
            idchar = '*';

            Score = 50;
        }
    }
}
