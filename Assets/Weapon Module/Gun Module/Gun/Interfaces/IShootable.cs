namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IShootable : IImageViewable
    {
        void Hide();
        void Show();
        void Shoot();
        IMagazine Magazine { get; }
    }
}