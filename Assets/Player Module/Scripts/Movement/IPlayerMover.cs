using Assets.Playable_Entity_Module.IMover;
using System;
using UnityEngine;

namespace Assets.Player_Module.Scripts
{
    public interface IPlayerMover
    {
        public float Speed { get; }

        void StartMove();
        void StopMove();
        void Moving(Transform transform);
        void DebaffSpeed(float speed);
        void ResetSpeed();

        public event Action<Vector2> InputDirectionUpdated;
        public event Action<Vector2> MovementDirectionUpdated;
    }
}
