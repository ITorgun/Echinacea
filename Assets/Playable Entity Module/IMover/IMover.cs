using UnityEngine;

namespace Assets.Playable_Entity_Module.IMover
{
    public interface IMover
    {
        void StartMove();
        void StopMove();
        void Moving(float deltaTime);
    }
}
