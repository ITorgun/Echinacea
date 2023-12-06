using Assets.Player_Module.Scripts.Inventory;
using Assets.Weapon_Module.Gun_Module.Gun;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour, IPlayerInventory
{
    public PlayerBulletInventory BulletInventory { get; private set; }
    public AmmoSwitcher AmmoSwitcher { get; private set; }
    public PlayerGunInventory GunInventory { get; private set; }

    [Inject]
    public void Constructor(PlayerBulletInventory bulletInventory, AmmoSwitcher ammoSwitcher, PlayerGunInventory gunInventory)
    {
        BulletInventory = bulletInventory;
        AmmoSwitcher = ammoSwitcher;
        GunInventory = gunInventory;
    }
}