using PacMan.Abstracts;

namespace PacMan.Foods
{
    class LittleGoal: Food
    {
        public LittleGoal(Position position) : base(position)
        {
            id = "littlegoal";
            idchar = (char)183;
            Score = 10;
        }
    }
}
