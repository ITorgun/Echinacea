using System;

namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IBullet : IAmmo
    {
        void StartFlying();
        void Collide();
    }
}