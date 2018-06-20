using PacMan.Abstracts;
using PacMan.Interfaces;
using System;

namespace PacMan.Foods
{
    public class Empty:Food
    {
        public Empty(Position position):base(position)
        {
            Score = 0;
        }
        public static char GetCharElement()
        {
            return ' ';
        }
    }
}
