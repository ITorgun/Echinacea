using Assets.Weapon_Module.Gun_Module.Gun;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    public BulletInventory BulletInventory { get; private set; }
    public AmmoSwitcher AmmoSwitcher { get; private set; }
    public GunInventory GunInventory { get; private set; }

    [Inject]
    public void Constructor(BulletInventory bulletInventory, AmmoSwitcher ammoSwitcher, GunInventory gunInventory)
    {
        BulletInventory = bulletInventory;
        AmmoSwitcher = ammoSwitcher;
        GunInventory = gunInventory;
    }
}