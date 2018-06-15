using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class Cherry:Food
    {
        public Cherry(IPosition position) : base(position)
        {
            Score = 100;
        }

        public static char GetCharElement()
        {
            return 'A';
        }

        public static int GetNumberElement()
        {
            return 4;
        }
    }
}
