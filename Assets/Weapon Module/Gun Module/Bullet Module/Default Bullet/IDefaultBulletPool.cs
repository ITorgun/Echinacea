using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet.Scripts;

namespace Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet
{
    public interface IDefaultBulletPool : IAmmoPool
    {
        IAmmo GetBullet();
        void InjectBulletType(DefaultBulletType bulletType);
    }
}
