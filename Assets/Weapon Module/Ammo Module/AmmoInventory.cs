using System.Collections.Generic;

public class AmmoInventory
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

    public int GetAvaibleBullet(int index, IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultMagazine:
                return (int)_defaultBulletTypes[index];

            case StrongMagazine:
                return (int)_strongBulletTypes[index];

            default:
                throw new System.Exception();
        }
    }

    public int GetAvaibleTypeCount(IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultMagazine:
                return _defaultBulletTypes.Count;

            case StrongMagazine:
                return _strongBulletTypes.Count;

            default:
                throw new System.Exception();
        }
    }
}
