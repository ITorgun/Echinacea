using UnityEngine;

namespace Assets.PlayableEntityModule.Mover
{
    public interface IMover : IMovable
    {
        void StartMove();
        void StopMove();
        void Moving(Transform transform);
    }
}
