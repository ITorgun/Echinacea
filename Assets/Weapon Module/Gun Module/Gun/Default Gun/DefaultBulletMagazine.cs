using Assets.WeaponModule.GunModule.Gun;

public class DefaultBulletMagazine : IMagazine
{
    private DefaultBulletPool _pool;
    private DefaultBulletType _type;

    public DefaultBulletMagazine(AmmoPool pool, DefaultBulletType bulletType)
    {
        _pool = (DefaultBulletPool)pool;
        _type = bulletType;
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
