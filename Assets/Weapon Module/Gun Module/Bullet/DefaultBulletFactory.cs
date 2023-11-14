using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class DefaultBulletFactory
    {
        private const string ConfigPath = "IBulletConfigs/DefaultBulletConfigs";

        private Dictionary<DefaultBulletType, DefaultBulletConfig> _configDictionary;
        private DiContainer _container;

        public DefaultBulletFactory(DiContainer container)
        {
            _container = container;
            _configDictionary = new Dictionary<DefaultBulletType, DefaultBulletConfig>();
            LoadConfigs();
        }

        public DefaultBullet Get(DefaultBulletType type, Transform bulletTranform, Transform parent)
        {
            DefaultBulletConfig config = GetConfig(type);
            DefaultBullet bullet = _container.InstantiatePrefabForComponent<DefaultBullet>(
                config.Prefab,
                bulletTranform.position,
                bulletTranform.rotation,
                parent);
            bullet.Init(config);
            return bullet;
        }

        private void LoadConfigs()
        {
            DefaultBulletConfig[] configs = Resources.LoadAll<DefaultBulletConfig>(ConfigPath);

            foreach (DefaultBulletConfig config in configs)
            {
                _configDictionary.Add(config.BulletType, config);
            }
        }

        private DefaultBulletConfig GetConfig(DefaultBulletType type)
        {
            if (_configDictionary.TryGetValue(type, out DefaultBulletConfig config) == false)
                throw new ArgumentException($"{type} isn't exist!");

            return config;
        }
    }
}