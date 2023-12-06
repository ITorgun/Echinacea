using Assets.Player_Module.Scripts.Inventory;
using Assets.Weapon_Module.Interfaces;
using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections.Generic;

public class PlayerBulletInventory : IPlayerBulletInventory
{
    private List<DefaultBulletType> _defaultBulletTypes = new List<DefaultBulletType>()
    {
        DefaultBulletType.WeakConfig,
        //DefaultBulletType.StrongConfig,
        //DefaultBulletType.TestConfig
    };

    public List<StrongBulletType> _strongBulletTypes = new List<StrongBulletType>()
    {
        StrongBulletType.ShortLife,
    };

    public bool TryAddBulletType(BulletConfig config)
    {
        switch (config)
        {
            case StrongBulletConfig strongConfig:

                if (_strongBulletTypes.Contains(strongConfig.BulletType))
                    return false;

                _strongBulletTypes.Add(strongConfig.BulletType);
                break;

            case DefaultBulletConfig defaultConfig:

                if (_defaultBulletTypes.Contains(defaultConfig.BulletType)) 
                    return false;

                _defaultBulletTypes.Add(defaultConfig.BulletType);
                break;

            default:
                throw new ArgumentException("Bullet type couldn't be found");
        }
        return true;
    }

    public void InjectBulletType(int avaibleInventoryIndex, IMagazine magazine)
    {
        switch (magazine)
        {
            case IDefaultMagazine defaulltMagazine:
                defaulltMagazine.InjectBulletType(_defaultBulletTypes[avaibleInventoryIndex]);
                return;

            case IStrongMagazine strongMagazine:
                strongMagazine.InjectBulletType(_strongBulletTypes[avaibleInventoryIndex]);
                return;

            default:
                throw new Exception();
        }
    }

    public int GetAvaibleBulletTypeCount(IMagazine magazine)
    {
        switch (magazine)
        {
            case IDefaultMagazine:
                return _defaultBulletTypes.Count;

            case IStrongMagazine:
                return _strongBulletTypes.Count;

            default:
                throw new Exception();
        }
    }
}
