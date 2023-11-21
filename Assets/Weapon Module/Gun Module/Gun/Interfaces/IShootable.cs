namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IShootable
    {
        void Hide();
        void Show();
        void Shoot();
        IMagazine Magazine { get; }
    }
}