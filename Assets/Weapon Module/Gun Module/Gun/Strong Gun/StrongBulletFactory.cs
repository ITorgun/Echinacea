using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StrongBulletFactory
{
    private const string ConfigPath = "IBulletConfigs/StrongBulletConfigs";

    private Dictionary<StrongBulletType, StrongBulletConfig> _configDictionary;
    private DiContainer _container;

    public StrongBulletFactory(DiContainer container)
    {
        _container = container;
        _configDictionary = new Dictionary<StrongBulletType, StrongBulletConfig>();
        LoadConfigs();
    }

    public StrongBullet Get(StrongBulletType type, Transform bulletTranform, Transform parent)
    {
        StrongBulletConfig config = GetConfig(type);
        StrongBullet bullet = _container.InstantiatePrefabForComponent<StrongBullet>(
            config.Prefab,
            bulletTranform.position,
            bulletTranform.rotation,
            parent);
        bullet.Init(config);
        return bullet;
    }

    private void LoadConfigs()
    {
        StrongBulletConfig[] configs = Resources.LoadAll<StrongBulletConfig>(ConfigPath);

        foreach (StrongBulletConfig config in configs)
        {
            _configDictionary.Add(config.BulletType, config);
        }
    }

    private StrongBulletConfig GetConfig(StrongBulletType type)
    {
        if (_configDictionary.TryGetValue(type, out StrongBulletConfig config) == false)
            throw new ArgumentException($"{type} isn't exist!");

        return config;
    }
}
