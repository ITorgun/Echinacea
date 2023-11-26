using Assets.WeaponModule.GunModule.Gun;

public interface IRangeAttackDealer : IShooter, ISwitcherShootable
{
    IShootable Shootable { get; }
}
