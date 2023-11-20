using System.Collections.Generic;

public class AmmoInventory
{
    private List<DefaultBulletType> _defaultBulletTypes = new List<DefaultBulletType>()
    {
        DefaultBulletType.WeakConfig,
        DefaultBulletType.StrongConfig,
        DefaultBulletType.TestConfig
    };

    public List<StrongBulletType> strongBulletTypes = new List<StrongBulletType>()
    {
        StrongBulletType.Lol,
        StrongBulletType.Kek
    };

    public int GetAvaibleBullet(int index, IMagazine magazine)
    {
        switch (magazine)
        {
            case DefaultMagazine:
                return (int)_defaultBulletTypes[index];

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

            default:
                throw new System.Exception();
        }
    }
}
