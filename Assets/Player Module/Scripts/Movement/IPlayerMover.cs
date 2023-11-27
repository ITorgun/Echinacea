using Assets.Playable_Entity_Module.Mover;
using System;
using UnityEngine;

namespace Assets.Player_Module.Scripts
{
    public interface IPlayerMover : IMover
    {
        public event Action<Vector2> InputDirectionUpdated;
        public event Action<Vector2> MovementDirectionUpdated;
    }
}
