using System;
using UnityEngine;

namespace Assets.WeaponModule.GunModule.Gun
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "SO/BulletConfigs/DefaultBulletConfig")]
    public class DefaultBulletConfig : BulletConfig
    {
        [SerializeField] private DefaultBullet _prefab;
        [SerializeField] private DefaultBulletType _bulletType;

        public DefaultBullet Prefab => _prefab;
        public DefaultBulletType BulletType => _bulletType;
    }
}