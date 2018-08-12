using System;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    interface ISinkAboutKillPacman
    {
        event Func<Task> SinkAboutKillPacman;
    }
}
