using UnityEngine;

namespace Assets.PlayableEntityModule.Finder
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
