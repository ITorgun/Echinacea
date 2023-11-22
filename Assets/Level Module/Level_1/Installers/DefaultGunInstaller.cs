using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class DefaultGunInstaller : MonoInstaller
{
    [SerializeField] private AmmoPool _defaultBulletPoolPrefab;
    [SerializeField] private DefaultGun _defaultGunPrefab;

    private GunInventory _gunInventory;

    private AmmoPool _ammoPool;
    private DefaultGun _gun;

    [Inject]
    public void Constructor(GunInventory gunInventory)
    {
        _gunInventory = gunInventory;
    }

    public override void InstallBindings()
    {
        InstallBulletFactory();
        InstallBulletPool();
        InstallMagazine();
        InstallGun();
    }

    private void InstallBulletFactory()
    {
        Container.Bind<DefaultBulletFactory>().AsSingle();
    }

    private void InstallBulletPool()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletPool>().NonLazy();

        _ammoPool = Container.InstantiatePrefabForComponent<AmmoPool>(_defaultBulletPoolPrefab);
        Container.BindInterfacesAndSelfTo<AmmoPool>()
            .FromInstance(_ammoPool).AsTransient().WhenInjectedInto<DefaultBulletMagazine>().NonLazy();
    }

    private void InstallMagazine()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletMagazine>().NonLazy();

        Container.BindInterfacesAndSelfTo<DefaultBulletMagazine>().WhenInjectedInto<DefaultGun>().NonLazy();
    }

    private void InstallGun()
    {
        _gun = Container.InstantiatePrefabForComponent<DefaultGun>(_defaultGunPrefab);

        _gun.transform.position = _gunInventory.transform.position;
        _gun.transform.SetParent(_gunInventory.transform);

        Container.BindInterfacesAndSelfTo<DefaultGun>()
            .FromInstance(_gun).AsSingle().NonLazy();
    }
}
