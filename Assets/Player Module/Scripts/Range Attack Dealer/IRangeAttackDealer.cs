using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangeAttackDealer : IShooter, IAmmoLoader
{
    IShootable Shootable { get; }
}
