using Assets.Playable_Entity_Module.IMover;
using System;
using UnityEngine;

namespace Assets.Player_Module.Scripts
{
    public interface IPlayerMover
    {
        void StartMove();
        void StopMove();
        void Moving();

        public event Action<Vector2> InputDirectionUpdated;
        public event Action<Vector2> MovementDirectionUpdated;
    }
}
