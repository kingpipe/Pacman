using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Foods
{
    public class Empty:Food
    {
        public Empty(IPosition position):base(position)
        {
            Score = 0;
        }
        public static char GetCharElement()
        {
            return ' ';
        }

        public static int GetNumberElement()
        {
            return 0;
        }
    }
}
