using Assets.PlayerModule;
using UnityEngine;

namespace Assets.Enemy_Module.Interfaces
{
    public interface IFinder
    {
        bool IsFinding { get; }
        //Transform FinderTransform { get; }
        float Range { get; }

        void StartFind();
        void StopFind();
        bool TryFindPosition(Vector2 currentPosition, out Vector2 finderPosition);
    }
}
