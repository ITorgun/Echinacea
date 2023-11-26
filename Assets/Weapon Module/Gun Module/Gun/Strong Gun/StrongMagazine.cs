using Assets.Weapon_Module.Ammo_Module.Interfaces;
using Assets.Weapon_Module.Interfaces;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine.UI;

public class StrongMagazine : IStrongMagazine
{
    private IStrongBulletPool _pool;
    private Image _image;

    public Image Image => _image;

    public StrongBulletType BulletType { get; private set; }

    public StrongMagazine(IStrongBulletPool pool, StrongBulletType bulletType, StrongMagazineConfig config)
    {
        _pool = pool;
        BulletType = bulletType;
        _image = config.Image;
    }

    public void InjectBulletType(StrongBulletType bulletType)
    {
        BulletType = bulletType;
        _pool.InjectBulletType(BulletType);
    }

    public IAmmo PullAmmo()
    {
        return _pool.GetBullet();
    }
}
