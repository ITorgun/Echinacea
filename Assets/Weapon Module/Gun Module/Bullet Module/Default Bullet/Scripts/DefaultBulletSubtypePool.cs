using Assets.Weapon_Module.Ammo_Module.Interfaces;
using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet;
using Assets.WeaponModule.GunModule.Gun;
using System.Collections.Generic;
using System;
using Zenject;

public class DefaultBulletSubtypePool : AmmoSubtypePool, IDefaultBulletPool
{
    private IDefaultBulletFactory _factory;
    private ShootPosition _shotTranform;

    private DefaultBulletType _currentType;

    [Inject]
    public void Construct (IDefaultBulletFactory factory,
        ShootPosition shotTranform, DefaultBulletType type)
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

    public void InjectBulletType(DefaultBulletType bulletType)
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
        DefaultBullet bullet = _factory.GetDefaultBullet(_currentType, _shotTranform.CurrentPosition, transform);
        bullet.Collided += OnAmmoCollided;
        return bullet;
    }

    public override void InitAmmo(IAmmo ammo)
    {
        DefaultBullet bullet = (DefaultBullet)ammo;
        bullet.transform.SetPositionAndRotation(_shotTranform.CurrentPosition.position, _shotTranform.transform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartFlying(_shotTranform.CurrentVector);
    }

    public override void OnRelease(IAmmo ammo)
    {
        ammo.Hide();
    }
}
