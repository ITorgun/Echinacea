using Assets.WeaponModule.GunModule.Gun;
using Zenject;

public class StrongBulletPool : AmmoPool
{
    private StrongBulletFactory _factory;
    private IShootPosition _shotTranform;

    private StrongBulletType _currentType;

    [Inject]
    public void Construct(StrongBulletFactory factory,
        IShootPosition shotTranform, StrongBulletType type)
    {
        Construct(10, 50);
        _factory = factory;
        _shotTranform = shotTranform;
        _currentType = type;
    }

    public void InjectAmmoType(StrongBulletType type)
    {
        _currentType = type;
        ClearPool();
    }

    protected override IAmmo Create()
    {
        IAmmo bullet = _factory.Get(_currentType, _shotTranform.CurrentPosition, transform);
        bullet.Collided += OnAmmoCollided;
        return bullet;
    }

    protected override void InitAmmo(IAmmo ammo)
    {
        StrongBullet bullet = (StrongBullet)ammo;
        bullet.transform.position = _shotTranform.CurrentPosition.position;
        bullet.gameObject.SetActive(true);
        bullet.StartFlying(_shotTranform.CurrentVector);
    }

    protected override void OnRelease(IAmmo ammo)
    {
        ammo.Hide();
    }
}
