using Assets.Playable_Entity_Module.Finder;
using UnityEngine;

namespace Assets.Enemy_Module.PlayerFinder
{
    public interface IPlayerPositionFinder : IFinder
    {
        public Vector2 LastPlayerPosition { get; }
    }
}
