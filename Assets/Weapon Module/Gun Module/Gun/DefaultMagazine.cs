using Assets.WeaponModule.GunModule.Gun;

public class DefaultMagazine : IMagazine
{
    private DefaultBulletPool _pool;
    private DefaultBulletType _type;

    public DefaultMagazine(DefaultBulletPool pool, DefaultBulletType bulletType)
    {
        _pool = pool;
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
