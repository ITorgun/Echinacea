using Assets.InputModule;
using Assets.WeaponModule.GunModule.Gun;
using System;
using Zenject;

public class DefaultRangeAttackDealer : IRangeAttackDealer, IDisposable
{
    private IRangeAttackEvents _rangeAttackEvents;
    private PlayerShootPosition _shotPosition;
    private PlayerModel _model;

    public IShootable Shootable { get; private set; }

    [Inject]
    public DefaultRangeAttackDealer(IRangeAttackEvents rangeAttackEvents, PlayerShootPosition shotPosition,
        PlayerModel model)
    {
        _rangeAttackEvents = rangeAttackEvents;

        //_rangeAttackEvents.RangeAttackPressed += Shoot;
        _rangeAttackEvents.RangeAttackPressed += Shoot;

        _shotPosition = shotPosition;
        _model = model;
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
        _model.PlayShootAnimation(_shotPosition.CurrentVector);
    }
}