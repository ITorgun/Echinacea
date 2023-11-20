using Assets.PlayerModule;
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

    [Inject]
    public Player Player { get; set; }

    public override void InstallBindings()
    {
        Container.Bind<AmmoInventory>().AsSingle().NonLazy();
        InstallDefaultBulletFactory();
        InstallShotPosition();
        InstallBulletPool();
        InstallMagazine();
        InstallGun();
        InstallPlayerShooter();
        InstallAmmoSwitcher();

        InstallPlayerAttack();
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
            .FromInstance(_ammoPoolInstance).AsSingle().NonLazy();
    }

    private void InstallMagazine()
    {
        StrongBulletType type = StrongBulletType.ShortLife;
        Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<StrongMagazine>().NonLazy();

        Container.BindInterfacesAndSelfTo<StrongMagazine>().AsSingle().NonLazy();
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

        _gunInstance.transform.position = playerAttack.transform.position;
        _gunInstance.transform.SetParent(playerAttack.transform);

        Container.BindInterfacesAndSelfTo<PlayerAttack>()
            .FromInstance(playerAttack).AsSingle().NonLazy();
    }
}
