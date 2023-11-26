using Assets.WeaponModule.GunModule.Gun;
using System;
using Zenject;

public class DefaultRangeAttackDealer : IRangeAttackDealer, IDisposable
{
    private IRangeAttackEvents _rangeAttackEvents;

    public IShootable Shootable { get; private set; }

    [Inject]
    public DefaultRangeAttackDealer(IRangeAttackEvents rangeAttackEvents)
    {
        _rangeAttackEvents = rangeAttackEvents;

        _rangeAttackEvents.RangeAttackPressed += Shoot;
    }

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
}