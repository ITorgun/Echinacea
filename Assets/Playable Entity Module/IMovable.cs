using UnityEngine;

namespace Assets.Playable_Entity_Module
{
    public interface IMovable
    {
        public float Speed { get; }
        public Transform Transform { get; }
    }
}
