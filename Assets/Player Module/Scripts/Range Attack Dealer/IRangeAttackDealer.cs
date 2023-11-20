using Assets.WeaponModule.GunModule.Gun;

public interface IRangeAttackDealer : IShooter, IAmmoLoader
{
    IShootable Shootable { get; }
}
