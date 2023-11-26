using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet.Scripts;

namespace Assets.Weapon_Module.Ammo_Module.Interfaces
{
    public interface IStrongBulletPool : IAmmoPool
    {
        IAmmo GetBullet();
        void InjectBulletType(StrongBulletType bulletType);
    }
}
