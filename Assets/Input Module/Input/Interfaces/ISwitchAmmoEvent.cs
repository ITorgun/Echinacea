using System;

namespace Assets.InputModule
{
    public interface ISwitchAmmoEvent
    {
        abstract event Action AmmoSwitched;
    }
}