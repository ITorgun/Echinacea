using Assets.Weapon_Module.Ammo_Module.Interfaces;
using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletFactory : IDefaultBulletFactory, IStrongBulletFactory
{
    private const string DefaultConfigsPath = "IBulletConfigs/DefaultBulletConfigs";
    private const string StrongConfigPath = "IBulletConfigs/StrongBulletConfigs";

    private DiContainer _container;

    private Dictionary<DefaultBulletType, DefaultBulletConfig> _defaultConfigsDictionary;
    private Dictionary<StrongBulletType, StrongBulletConfig> _strongConfigDictionary;

    public BulletFactory(DiContainer container)
    {
        _container = container;
        _defaultConfigsDictionary = new Dictionary<DefaultBulletType, DefaultBulletConfig>();
        _strongConfigDictionary = new Dictionary<StrongBulletType, StrongBulletConfig>();
        LoadConfigs();
    }

    public DefaultBullet GetDefaultBullet(DefaultBulletType type, Transform bulletTranform, Transform parent)
    {
        DefaultBulletConfig config = GetDefaultConfig(type);
        DefaultBullet bullet = _container.InstantiatePrefabForComponent<DefaultBullet>(
            config.Prefab,
            bulletTranform.position,
            bulletTranform.rotation,
            parent);
        bullet.Init(config);
        return bullet;
    }

    public StrongBullet GetStrongBullet(StrongBulletType type, Transform bulletTranform, Transform parent)
    {
        StrongBulletConfig config = GetStongConfig(type);
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
        LoadDefaultConfigs();
        LoadStrongConfigs();
    }

    private void LoadDefaultConfigs()
    {
        DefaultBulletConfig[] configs = Resources.LoadAll<DefaultBulletConfig>(DefaultConfigsPath);

        foreach (DefaultBulletConfig config in configs)
        {
            _defaultConfigsDictionary.Add(config.BulletType, config);
        }
    }

    private void LoadStrongConfigs()
    {
        StrongBulletConfig[] configs = Resources.LoadAll<StrongBulletConfig>(StrongConfigPath);

        foreach (StrongBulletConfig config in configs)
        {
            _strongConfigDictionary.Add(config.BulletType, config);
        }
    }

    private DefaultBulletConfig GetDefaultConfig(DefaultBulletType type)
    {
        if (_defaultConfigsDictionary.TryGetValue(type, out DefaultBulletConfig config) == false)
            throw new ArgumentException($"{type} isn't exist!");

        return config;
    }

    private StrongBulletConfig GetStongConfig(StrongBulletType type)
    {
        if (_strongConfigDictionary.TryGetValue(type, out StrongBulletConfig config) == false)
            throw new ArgumentException($"{type} isn't exist!");

        return config;
    }
}
