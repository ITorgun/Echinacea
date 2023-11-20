
using UnityEngine;

namespace Assets.Playable_Entity_Module
{
    public interface IPositionable
    {
        Vector2 Position { get; set; }
        bool IsPositionSet { get; set; }
    }
}
