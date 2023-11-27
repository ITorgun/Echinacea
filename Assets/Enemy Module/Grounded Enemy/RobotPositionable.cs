using Assets.Playable_Entity_Module;
using UnityEngine;

namespace Assets.Enemy_Module.Grounded_Enemy
{
    public class RobotPositionable : IPositionable
    {
        public Vector2 Position { get; set; }
        public bool IsPositionSet { get; set; }
    }
}
