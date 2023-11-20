using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongMagazine : IMagazine
{
    private StrongBulletPool _pool;
    private StrongBulletType _type;

    public StrongMagazine(AmmoPool pool, StrongBulletType bulletType)
    {
        _pool = (StrongBulletPool)pool;
        _type = bulletType;
    }

    public void LoadAmmo(int ammoEnumValue)
    {
        _type = (StrongBulletType)ammoEnumValue;
        _pool.InjectAmmoType(_type);
    }

    public IAmmo PullAmmo()
    {
        return _pool.Get();
    }
}
