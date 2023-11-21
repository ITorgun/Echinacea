using Assets.PlayerModule;
using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class StrongGunInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _defaultBulletPool;
    [SerializeField] private StrongGun _defaultGun;
    [SerializeField] private ShotPosition _shotPosition;
    [SerializeField] private PlayerAttack _playerAttack;

    private ShotPosition _shotPositionInstance;
    private AmmoPool _ammoPoolInstance;
    private StrongGun _gunInstance;

    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GunInventory _gunInventory;

    [Inject]
    public Player Player { get; set; }

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

        InstallPlayerAttack();
        GunInventoryInstaller();
        //PlayerInventoryInstaller();
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
        _gunInstance = Container.InstantiatePrefabForComponent<StrongGun>(_defaultGun);
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

    private void InstallPlayerAttack()
    {
        PlayerAttack playerAttack = Container.InstantiatePrefabForComponent<PlayerAttack>(_playerAttack, Player.transform);
        playerAttack.transform.position = Player.transform.position;

        _shotPositionInstance.transform.position = playerAttack.transform.position;
        _shotPositionInstance.transform.SetParent(playerAttack.transform);

        Container.BindInterfacesAndSelfTo<PlayerAttack>()
            .FromInstance(playerAttack).AsSingle().NonLazy();
    }

    private void GunInventoryInstaller()
    {
        GunInventory gunInventory = Container.InstantiatePrefabForComponent<GunInventory>(_gunInventory, Player.transform);
        gunInventory.transform.position = Player.transform.position;

        _gunInstance.transform.position = gunInventory.transform.position;
        _gunInstance.transform.SetParent(gunInventory.transform);

        Container.BindInterfacesAndSelfTo<GunInventory>().FromInstance(gunInventory).AsSingle().NonLazy();
    }

    //private void PlayerInventoryInstaller()
    //{
    //    PlayerInventory playerInventory = Container.InstantiatePrefabForComponent<PlayerInventory>(_playerInventory, Player.transform);
    //    playerInventory.transform.position = Player.transform.position;

    //    Container.BindInterfacesAndSelfTo<PlayerInventory>().FromInstance(playerInventory).AsSingle().NonLazy();
    //}
}
