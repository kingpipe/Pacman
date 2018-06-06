using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PositionElement
    {
        public Position position { get; private set; }
        public Elements element { get; private set; }
        public PositionElement(Position coord, Elements element)
        {
            this.position = coord;
            this.element = element;
        }
    }
}
