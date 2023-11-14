using Assets.WeaponModule.GunModule.Gun;
using Zenject;
using Zenject.SpaceFighter;

public class DefaultBulletPool : AmmoPool
{
    private DefaultBulletFactory _factory;
    private ShotPosition _shotTranform;

    private DefaultBulletType _currentType;

    [Inject]
    public void Construct (DefaultBulletFactory factory,
        ShotPosition shotTranform, DefaultBulletType type)
    {
        Construct(10, 50);
        _factory = factory;
        _shotTranform = shotTranform;
        _currentType = type;
    }

    public void InjectAmmoType(DefaultBulletType type)
    {
        _currentType = type;
        ClearPool();
    }

    protected override IAmmo Create()
    {
        DefaultBullet bullet = _factory.Get(_currentType, _shotTranform.CurrentPosition, transform);
        bullet.Collided += OnAmmoCollided;
        return bullet;
    }

    protected override void InitAmmo(IAmmo ammo)
    {
        DefaultBullet bullet = (DefaultBullet)ammo;
        bullet.transform.SetPositionAndRotation(_shotTranform.CurrentPosition.position, _shotTranform.transform.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartFlying(_shotTranform.CurrentVector);
    }

    protected override void OnRelease(IAmmo ammo)
    {
        ammo.Hide();
    }
}
