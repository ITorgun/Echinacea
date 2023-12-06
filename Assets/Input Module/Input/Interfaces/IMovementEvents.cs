using System;

namespace Assets.InputModule
{
    public interface IMovementEvents
    {
        public event Action<float> Horizontal;
        public event Action<float> Vertical;
    }
}