using Assets.WeaponModule.GunModule.Gun;

public interface IBulletTradeable
{
    public bool TryBuyBullet(int price, BulletConfig config);
}
