using System;

namespace Assets.Player_Module.Scripts
{
    public interface IDieEvent<T>
    {
        public event Action<T> Died;
    }
}
