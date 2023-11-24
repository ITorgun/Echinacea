using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StrongGunInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _bulletPoolPrefab;
    [SerializeField] private StrongGun _gunPrefab;
    [SerializeField] private StrongMagazineConfig _config;

    private AmmoPool _ammoPool;
    private StrongGun _gun;

    public override void InstallBindings()
    {
        InstallBulletFactory();
        InstallBulletPool();
        InstallMagazine();
        InstallGun();
        InstallPlayerShooter();
        InstallAmmoSwitcher();

    }

    private void InstallBulletFactory()
    {
        Container.Bind<StrongBulletFactory>().AsSingle();
    }

    private void InstallBulletPool()
    {
        StrongBulletType type = StrongBulletType.ShortLife;
        Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<StrongBulletPool>().NonLazy();

        _ammoPool = Container.InstantiatePrefabForComponent<AmmoPool>(_bulletPoolPrefab);
        Container.BindInterfacesAndSelfTo<AmmoPool>()
            .FromInstance(_ammoPool).AsTransient().WhenInjectedInto<StrongMagazine>().NonLazy();
    }

    private void InstallMagazine()
    {
        StrongBulletType type = StrongBulletType.ShortLife;
        Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<StrongMagazine>().NonLazy();

        Container.BindInstance(_config).AsSingle();

        Container.BindInterfacesAndSelfTo<StrongMagazine>().WhenInjectedInto<StrongGun>().NonLazy();
    }

    private void InstallGun()
    {
        _gun = Container.InstantiatePrefabForComponent<StrongGun>(_gunPrefab);
        Container.BindInterfacesAndSelfTo<StrongGun>()
            .FromInstance(_gun).AsSingle().NonLazy();
    }

    private void InstallPlayerShooter()
    {
        Container.BindInterfacesAndSelfTo<DefaultRangeAttackDealer>().AsSingle().NonLazy();
    }

    private void InstallAmmoSwitcher()
    {
        Container.BindInterfacesAndSelfTo<AmmoSwitcher>().AsSingle().NonLazy();
    }
}