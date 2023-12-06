using System;

namespace Assets.WeaponModule.GunModule.Gun
{
    public interface IShootable : IImageViewable
    {
        //public bool IsCooldowned { get; }

        public void Hide();
        public void Show();
        public void Shoot();
        public IMagazine Magazine { get; }
    }
}