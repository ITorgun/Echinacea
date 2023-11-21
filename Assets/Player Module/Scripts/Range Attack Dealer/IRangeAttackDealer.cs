using Assets.WeaponModule.GunModule.Gun;

public interface IRangeAttackDealer : IShooter, IAmmoLoader, ISwitcherShootable
{
    IShootable Shootable { get; }
}
