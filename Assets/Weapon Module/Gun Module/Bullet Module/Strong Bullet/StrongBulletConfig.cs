using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "SO/BulletConfigs/StrongBulletConfig")]
public class StrongBulletConfig : BulletConfig
{
    [SerializeField] private StrongBullet _prefab;
    [SerializeField] private StrongBulletType _bulletType;

    public StrongBullet Prefab => _prefab;
    public StrongBulletType BulletType => _bulletType;
}
