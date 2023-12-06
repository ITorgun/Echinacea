using Assets.Weapon_Module.Ammo_Module.Interfaces;
using Assets.Weapon_Module.Interfaces;
using System;
using UnityEngine.UI;

public class StrongMagazine : IStrongMagazine
{
    private IStrongBulletPool _pool;
    private Image _image;
    private StrongMagazineConfig _config;

    public Image Image => _image;
    public StrongBulletType BulletType { get; private set; }

    public StrongMagazine(IStrongBulletPool pool, StrongBulletType bulletType, StrongMagazineConfig config)
    {
        _pool = pool;
        BulletType = bulletType;
        _config = config;

        SwitchImage(bulletType);
    }

    public void InjectBulletType(StrongBulletType bulletType)
    {
        BulletType = bulletType;
        _pool.InjectBulletType(BulletType);
        SwitchImage(bulletType);
    }

    public IAmmo PullAmmo()
    {
        return _pool.GetBullet();
    }

    public void SwitchImage(StrongBulletType bulletType)
    {
        switch (bulletType)
        {
            case StrongBulletType.WeakConfig:
                _image = _config.WeakImage;
                break;

            case StrongBulletType.FastSpeedConfig:
                _image = _config.FastImage;
                break;

            case StrongBulletType.ShortLife:
                _image = _config.ShortImage;
                break;

            default:
                throw new Exception("Cant switch image type");
        }
    }
}
