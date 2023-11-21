using System;
using System.Collections.Generic;

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

    public int GetBulletTypeByIndex(int index, IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultBulletMagazine:
                return (int)_defaultBulletTypes[index];

            case StrongMagazine:
                return (int)_strongBulletTypes[index];

            default:
                throw new Exception();
        }
    }

    public int GetAvaibleBulletTypeCount(IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultBulletMagazine:
                return _defaultBulletTypes.Count;

            case StrongMagazine:
                return _strongBulletTypes.Count;

            default:
                throw new Exception();
        }
    }
}
