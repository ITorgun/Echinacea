namespace Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet.Scripts
{
    public interface IAmmoPool
    {
        public int CountAll { get; }

        IAmmo Create();
        IAmmo Get();
        void Release(IAmmo element);
        void OnAmmoCollided(IAmmo ammo);
        void OnRelease(IAmmo ammo);
        void ClearPool();
        void InitAmmo(IAmmo ammo);
    }
}
