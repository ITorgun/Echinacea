using UnityEngine;

namespace Assets.Weapon_Module.Ammo_Module.Interfaces
{
    public interface IStrongBulletFactory
    {
        public StrongBullet GetStrongBullet(StrongBulletType type, Transform bulletTranform, Transform parent);
    }
}
