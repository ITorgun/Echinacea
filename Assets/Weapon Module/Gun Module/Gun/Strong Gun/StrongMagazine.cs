using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongMagazine : IMagazine
{
    private StrongBulletPool _pool;
    private StrongBulletType _type;
    private Image _image;

    public Image Image => _image;

    public StrongMagazine(AmmoPool pool, StrongBulletType bulletType, StrongMagazineConfig config)
    {
        _pool = (StrongBulletPool)pool;
        _type = bulletType;
        _image = config.Image;
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
