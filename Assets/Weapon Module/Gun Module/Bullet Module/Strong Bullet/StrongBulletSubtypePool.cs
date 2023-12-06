using Assets.Weapon_Module.Ammo_Module.Interfaces;
using Assets.WeaponModule.GunModule.Gun;
using System.Collections.Generic;
using System;
using Zenject;

public class StrongBulletSubtypePool : AmmoSubtypePool, IStrongBulletPool
{
    private IStrongBulletFactory _factory;
    private PlayerShootPosition _shotTranform;

    private StrongBulletType _currentType;

    [Inject]
    public void Construct(IStrongBulletFactory factory,
        PlayerShootPosition shotTranform, StrongBulletType type)
    {
        _factory = factory;
        _shotTranform = shotTranform;
        _currentType = type;
    }

    public void Init(int defaultCapacity = 10, int maxSize = 50)
    {
        if (maxSize <= 0)
        {
            throw new ArgumentException("Max Size must be greater than 0", "maxSize");
        }

        MaxSize = maxSize;
        GettedAmmoList = new List<IAmmo>(defaultCapacity);
        ReleasedAmmoList = new List<IAmmo>();
    }

    public void InjectBulletType(StrongBulletType bulletType)
    {
        _currentType = bulletType;
        ClearPool();
    }

    public IAmmo GetBullet()
    {
        return Get();
    }

    public override IAmmo Create()
    {
        StrongBullet bullet = _factory.GetStrongBullet(_currentType, _shotTranform.CurrentPosition, transform);
        bullet.Collided += OnAmmoCollided;
        return bullet;
    }

    public override void InitAmmo(IAmmo ammo)
    {
        StrongBullet bullet = (StrongBullet)ammo;
        bullet.transform.SetPositionAndRotation(_shotTranform.CurrentPosition.position, _shotTranform.transform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartFlying(_shotTranform.CurrentVector);
    }

    public override void OnRelease(IAmmo ammo)
    {
        ammo.Hide();
    }
}
