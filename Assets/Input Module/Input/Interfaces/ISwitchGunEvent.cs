using System;

namespace Assets.InputModule
{
    public interface ISwitchGunEvent
    {
        abstract event Action GunSwitched;
    }
}