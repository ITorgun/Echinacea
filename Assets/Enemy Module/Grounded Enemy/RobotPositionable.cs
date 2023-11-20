using Assets.Playable_Entity_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Enemy_Module.Grounded_Enemy
{
    internal class RobotPositionable : IPositionable
    {
        public Vector2 Position { get; set; }
        public bool IsPositionSet { get; set; }


    }
}
