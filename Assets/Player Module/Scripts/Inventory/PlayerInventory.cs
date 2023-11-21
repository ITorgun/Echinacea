using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    private BulletInventory _bulletInventory;
    private AmmoSwitcher _ammoSwitcher;
    private GunInventory _gunInventory;

    [Inject]
    public void Constructor(BulletInventory bulletInventory, AmmoSwitcher ammoSwitcher, GunInventory gunInventory)
    {
        _bulletInventory = bulletInventory;
        _ammoSwitcher = ammoSwitcher;
        _gunInventory = gunInventory;
    }



}
