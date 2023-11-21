using Assets.WeaponModule.GunModule.Gun;
using System;
using Zenject;

public class DefaultRangeAttackDealer : IRangeAttackDealer, IDisposable
{
    private IRangeAttackEvents _rangeAttackEvents;

    public IShootable Shootable { get; set; }

    [Inject]
    public DefaultRangeAttackDealer(IRangeAttackEvents rangeAttackEvents) //, IShootable shootable
    {
        _rangeAttackEvents = rangeAttackEvents;

        _rangeAttackEvents.RangeAttackPressed += Shoot;
    }

    //
    public void InjectShootable(IShootable shootable)
    {
        Shootable = shootable;
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