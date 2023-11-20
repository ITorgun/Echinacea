using Assets.PlayerModule;
using Assets.WeaponModule.GunModule.Gun;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GunModuleInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _defaultBulletPool;
    [SerializeField] private DefaultGun _defaultGun;

    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    public override void InstallBindings()
    {
        Container.Bind<AmmoInventory>().AsSingle().NonLazy();
        InstallDefaultBulletFactory();
        InstallDefaultBulletPool();
        InstallMagazine();
        InstallDefaultGun();
        InstallPlayerShooter();
        InstallAmmoSwitcher();
    }

    private void InstallDefaultBulletFactory()
    {
        Container.Bind<DefaultBulletFactory>().AsSingle();
    }

    private void InstallDefaultBulletPool()
    {
        DefaultBulletType type = DefaultBulletType.AverageConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletPool>().NonLazy();

        AmmoPool pool = Container.InstantiatePrefabForComponent<AmmoPool>(_defaultBulletPool);
        Container.BindInterfacesAndSelfTo<AmmoPool>()
            .FromInstance(pool).AsSingle().NonLazy();
    }

    private void InstallMagazine()
    {
        DefaultBulletType type = DefaultBulletType.AverageConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultMagazine>().NonLazy();

        Container.BindInterfacesAndSelfTo<DefaultMagazine>().AsSingle().NonLazy();
    }

    private void InstallDefaultGun()
    {
        DefaultGun gun = Container.InstantiatePrefabForComponent<DefaultGun>(_defaultGun, _player.transform);
        Container.BindInterfacesAndSelfTo<DefaultGun>()
            .FromInstance(gun).AsSingle().NonLazy();
    }

    private void InstallPlayerShooter()
    {
        Container.BindInterfacesAndSelfTo<PlayerShooter>().AsSingle().NonLazy();
    }

    private void InstallAmmoSwitcher()
    {
        Container.BindInterfacesAndSelfTo<AmmoSwitcher>().AsSingle().NonLazy();
    }
}
