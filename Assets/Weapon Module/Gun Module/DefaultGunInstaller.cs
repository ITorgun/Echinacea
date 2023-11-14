using Assets.PlayerModule;
using Assets.WeaponModule.GunModule.Gun;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DefaultGunInstaller : MonoInstaller
{
    [SerializeField] private DefaultBulletPool _defaultBulletPool;
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

        DefaultBulletPool pool = Container.InstantiatePrefabForComponent<DefaultBulletPool>(_defaultBulletPool);
        Container.BindInterfacesAndSelfTo<DefaultBulletPool>()
            .FromInstance(pool).AsSingle().NonLazy();
        //pool.transform.SetParent(_player.transform);
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
