using UnityEngine;

namespace Assets.Playable_Entity_Module.Mover
{
    public interface IMover : ISpeediable
    {
        void StartMove();
        void StopMove();
        void Moving(Transform transform);
    }
}
