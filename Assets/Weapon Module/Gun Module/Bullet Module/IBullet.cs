using System;
using UnityEngine;

namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IBullet : IAmmo
    {
        void StartFlying(Vector2 direction);
        void Collide();
    }
}