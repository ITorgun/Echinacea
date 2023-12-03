using Assets.Weapon_Module.Gun_Module.Gun;

namespace Assets.Player_Module.Scripts.Inventory
{
    public interface IPlayerInventory
    {
        public PlayerBulletInventory BulletInventory { get; }
        public AmmoSwitcher AmmoSwitcher { get; }
        public PlayerGunInventory GunInventory { get; }
    }
}
