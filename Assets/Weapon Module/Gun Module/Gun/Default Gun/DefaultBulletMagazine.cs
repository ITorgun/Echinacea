using Assets.WeaponModule.GunModule.Gun;
using UnityEngine.UI;

public class DefaultBulletMagazine : IMagazine
{
    private DefaultBulletPool _pool;
    private DefaultBulletType _type;
    private Image _image;

    public Image Image => _image;

    public DefaultBulletMagazine(AmmoPool pool, DefaultBulletType bulletType, DefaultMagazineConfig config)
    {
        _pool = (DefaultBulletPool)pool;
        _type = bulletType;
        _image = config.Image;
    }

    public void LoadAmmo(int ammoEnumValue)
    {
        _type = (DefaultBulletType)ammoEnumValue;
        _pool.InjectAmmoType(_type);
    }

    public IAmmo PullAmmo()
    {
        return _pool.Get();
    }
}
