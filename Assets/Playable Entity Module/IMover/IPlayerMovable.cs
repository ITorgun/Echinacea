using Assets.Player_Module.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Playable_Entity_Module.IMover
{
    public interface IPlayerMovable
    {
        IPlayerMover PlayerMover { get; }
    }
}
