using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet;
using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet.Scripts;
using Assets.Weapon_Module.Interfaces;
using UnityEngine.UI;

public class DefaultBulletMagazine : IDefaultMagazine
{
    private IDefaultBulletPool _pool;
    private Image _image;

    public DefaultBulletType BulletType { get; set; }

    public Image Image => _image;

    public DefaultBulletMagazine(IDefaultBulletPool pool, DefaultBulletType bulletType, DefaultMagazineConfig config)
    {
        _pool = pool;
        BulletType = bulletType;
        _image = config.Image;
    }

    public void InjectBulletType(DefaultBulletType bulletType)
    {
        BulletType = bulletType;
        _pool.InjectBulletType(BulletType);
    }

    public IAmmo PullAmmo()
    {
        return _pool.Get();
    }
}
