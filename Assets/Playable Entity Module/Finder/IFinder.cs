using UnityEngine;

namespace Assets.Playable_Entity_Module.Finder
{
    public interface IFinder
    {
        bool IsFinding { get; }
        float Range { get; }

        void StartFind();
        void StopFind();
        bool TryFindPosition(Vector2 currentPosition, out Vector2 finderPosition);
    }
}
