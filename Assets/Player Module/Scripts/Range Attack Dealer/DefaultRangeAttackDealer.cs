using Assets.WeaponModule.GunModule.Gun;
using System;
using Zenject;

public class DefaultRangeAttackDealer : IRangeAttackDealer, IDisposable
{
    private IRangeAttackEvents _rangeAttackEvents;

    [Inject]
    public IShootable Shootable { get; set; }

    [Inject]
    public DefaultRangeAttackDealer(IRangeAttackEvents rangeAttackEvents)
    {
        _rangeAttackEvents = rangeAttackEvents;
        _rangeAttackEvents.RangeAttackPressed += Shoot;
    }

    public void Dispose()
    {
        _rangeAttackEvents.RangeAttackPressed -= Shoot;
    }

    public void Shoot()
    {
        Shootable.Shoot();
    }

    public void LoadAmmo(int ammoEnumValue)
    {
        Shootable.Magazine.LoadAmmo(ammoEnumValue);
    }
}