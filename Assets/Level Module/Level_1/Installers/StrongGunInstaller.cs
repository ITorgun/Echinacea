using Assets.PlayerModule;
using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class StrongGunInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _defaultBulletPool;
    [SerializeField] private StrongGun _gun;

    [SerializeField] private ShotPosition _shotPosition;

    private ShotPosition _shotPositionInstance;
    private AmmoPool _ammoPoolInstance;
    private StrongGun _gunInstance;


    public override void InstallBindings()
    {
        Container.Bind<BulletInventory>().AsSingle().NonLazy();
        InstallDefaultBulletFactory();
        InstallShotPosition();
        InstallBulletPool();
        InstallMagazine();
        InstallGun();
        InstallPlayerShooter();
        InstallAmmoSwitcher();

    }

    private void InstallDefaultBulletFactory()
    {
        Container.Bind<StrongBulletFactory>().AsSingle();
    }

    private void InstallShotPosition()
    {
        _shotPositionInstance = Container.InstantiatePrefabForComponent<ShotPosition>(_shotPosition);
        Container.BindInterfacesAndSelfTo<ShotPosition>().FromInstance(_shotPositionInstance).AsSingle().NonLazy();
    }

    private void InstallBulletPool()
    {
        StrongBulletType type = StrongBulletType.ShortLife;
        Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<StrongBulletPool>().NonLazy();

        _ammoPoolInstance = Container.InstantiatePrefabForComponent<AmmoPool>(_defaultBulletPool);
        Container.BindInterfacesAndSelfTo<AmmoPool>()
            .FromInstance(_ammoPoolInstance).AsTransient().WhenInjectedInto<StrongMagazine>().NonLazy();
    }

    private void InstallMagazine()
    {
        StrongBulletType type = StrongBulletType.ShortLife;
        Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<StrongMagazine>().NonLazy();

        Container.BindInterfacesAndSelfTo<StrongMagazine>().WhenInjectedInto<StrongGun>().NonLazy();
    }

    private void InstallGun()
    {
        _gunInstance = Container.InstantiatePrefabForComponent<StrongGun>(_gun);
        Container.BindInterfacesAndSelfTo<StrongGun>()
            .FromInstance(_gunInstance).AsSingle().NonLazy();
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
