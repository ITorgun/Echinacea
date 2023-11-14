namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IShootable
    {
        void Shoot();
        IMagazine Magazine { get; }
    }
}