using Assets.PlayerModule;
using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class GunModuleInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _defaultBulletPool;
    [SerializeField] private DefaultGun _defaultGun;
    //[SerializeField] private ShotPosition _shotPosition;
    //[SerializeField] private PlayerAttack _playerAttack;

    private ShotPosition _shotPositionInstance;
    private AmmoPool _ammoPoolInstance;
    private DefaultGun _gunInstance;

    [Inject]
    public Player Player { get; set; }

    [Inject]
    private GunInventory GunInventory { get ; set; }

    public override void InstallBindings()
    {
        //Container.Bind<BulletInventory>().AsSingle().NonLazy();
        InstallDefaultBulletFactory();
        //InstallShotPosition();
        InstallDefaultBulletPool();
        InstallMagazine();
        InstallDefaultGun();
        //InstallPlayerShooter();
        //InstallAmmoSwitcher();

        //InstallPlayerAttack();
    }

    private void InstallDefaultBulletFactory()
    {
        Container.Bind<DefaultBulletFactory>().AsSingle();
    }

    //private void InstallShotPosition()
    //{
    //    _shotPositionInstance = Container.InstantiatePrefabForComponent<ShotPosition>(_shotPosition);
    //    Container.BindInterfacesAndSelfTo<ShotPosition>().FromInstance(_shotPositionInstance).AsSingle().NonLazy();
    //}

    private void InstallDefaultBulletPool()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletPool>().NonLazy();

        _ammoPoolInstance = Container.InstantiatePrefabForComponent<AmmoPool>(_defaultBulletPool);
        Container.BindInterfacesAndSelfTo<AmmoPool>()
            .FromInstance(_ammoPoolInstance).AsTransient().WhenInjectedInto<DefaultBulletMagazine>().NonLazy();
    }

    private void InstallMagazine()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletMagazine>().NonLazy();

        Container.BindInterfacesAndSelfTo<DefaultBulletMagazine>().WhenInjectedInto<DefaultGun>().NonLazy();
    }

    private void InstallDefaultGun()
    {
        _gunInstance = Container.InstantiatePrefabForComponent<DefaultGun>(_defaultGun);

        _gunInstance.transform.position = GunInventory.transform.position;
        _gunInstance.transform.SetParent(GunInventory.transform);

        Container.BindInterfacesAndSelfTo<DefaultGun>()
            .FromInstance(_gunInstance).AsSingle().NonLazy();
    }

    //private void InstallPlayerShooter()
    //{
    //    Container.BindInterfacesAndSelfTo<DefaultRangeAttackDealer>().AsSingle().NonLazy();
    //}

    //private void InstallAmmoSwitcher()
    //{
    //    Container.BindInterfacesAndSelfTo<AmmoSwitcher>().AsSingle().NonLazy();
    //}

    //private void InstallPlayerAttack()
    //{
    //    PlayerAttack playerAttack = Container.InstantiatePrefabForComponent<PlayerAttack>(_playerAttack, Player.transform);
    //    playerAttack.transform.position = Player.transform.position;

    //    _shotPositionInstance.transform.position = playerAttack.transform.position;
    //    _shotPositionInstance.transform.SetParent(playerAttack.transform);

    //    _gunInstance.transform.position = playerAttack.transform.position;
    //    _gunInstance.transform.SetParent(playerAttack.transform);

    //    Container.BindInterfacesAndSelfTo<PlayerAttack>()
    //        .FromInstance(playerAttack).AsSingle().NonLazy();
    //}
}
