using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Wall: IWall
    {
        public IPosition position { get; set; }

        public Wall(IPosition position)
        {
            this.position = position;
        }

        public static int GetNumberElement()
        {
            return 1;
        }

        public static char GetCharElement()
        {
            return '#';
        }
    }
}
