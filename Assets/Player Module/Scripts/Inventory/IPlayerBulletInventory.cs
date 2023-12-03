using Assets.WeaponModule.GunModule.Gun;

namespace Assets.Player_Module.Scripts.Inventory
{
    public interface IPlayerBulletInventory
    {
        public bool TryAddBulletType(BulletConfig config);

    }
}
