namespace Assets.Weapon_Module.Interfaces
{
    public interface IStrongMagazine : IMagazine
    {
        public StrongBulletType BulletType { get; }

        public void InjectBulletType(StrongBulletType bulletType);
        public void SwitchImage(StrongBulletType bulletType);
    }
}
