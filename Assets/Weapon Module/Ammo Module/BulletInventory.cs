using Assets.Weapon_Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

public class BulletInventory
{
    private List<DefaultBulletType> _defaultBulletTypes = new List<DefaultBulletType>()
    {
        DefaultBulletType.WeakConfig,
        DefaultBulletType.StrongConfig,
        DefaultBulletType.TestConfig
    };

    public List<StrongBulletType> _strongBulletTypes = new List<StrongBulletType>()
    {
        StrongBulletType.ShortLife,
        StrongBulletType.FastSpeedConfig,
    };

    public void InjectBulletType(int avaibleInventoryIndex, IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultBulletMagazine defaulltMagazine:
                defaulltMagazine.InjectBulletType(_defaultBulletTypes[avaibleInventoryIndex]);
                return;

            case StrongMagazine strongMagazine:
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
