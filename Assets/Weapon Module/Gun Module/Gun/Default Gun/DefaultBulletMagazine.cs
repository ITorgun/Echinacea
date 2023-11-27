using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet;
using Assets.Weapon_Module.Interfaces;
using System;
using UnityEngine.UI;

public class DefaultBulletMagazine : IDefaultMagazine
{
    private IDefaultBulletPool _pool;
    private DefaultMagazineConfig _config;
    private Image _image;

    public DefaultBulletType BulletType { get; set; }

    public Image Image => _image;

    public DefaultBulletMagazine(IDefaultBulletPool pool, DefaultBulletType bulletType, DefaultMagazineConfig config)
    {
        _pool = pool;
        BulletType = bulletType;
        _config = config;

        SwitchImage(BulletType);
    }

    public void InjectBulletType(DefaultBulletType bulletType)
    {
        BulletType = bulletType;
        SwitchImage(bulletType);
        _pool.InjectBulletType(BulletType);
    }

    public IAmmo PullAmmo()
    {
        return _pool.Get();
    }

    public void SwitchImage(DefaultBulletType bulletType)
    {
        switch (bulletType)
        {
            case DefaultBulletType.WeakConfig:
                _image = _config.WeakImage;
                break;

            case DefaultBulletType.AverageConfig:
                _image = _config.AverageImage;
                break;

            case DefaultBulletType.StrongConfig:
                _image = _config.StrongImage;
                break;

            case DefaultBulletType.TestConfig:
                _image = _config.TestImage;
                break;

            default:
                throw new Exception("Cant switch image type");
        }
    }
}
