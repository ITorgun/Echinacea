using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class DefaultGunInstaller : MonoInstaller
{
    [SerializeField] private AmmoSubtypePool _defaultBulletPoolPrefab;
    [SerializeField] private DefaultGun _defaultGunPrefab;
    [SerializeField] private DefaultMagazineConfig _config;

    private GunInventory _gunInventory;

    private AmmoSubtypePool _ammoPool;
    private DefaultGun _gun;

    [Inject]
    public void Constructor(GunInventory gunInventory)
    {
        _gunInventory = gunInventory;
    }

    public override void InstallBindings()
    {
        InstallBulletPool();
        InstallMagazine();
        InstallGun();
    }

    private void InstallBulletPool()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletSubtypePool>().NonLazy();

        DefaultBulletSubtypePool pool = Container.InstantiatePrefabForComponent<DefaultBulletSubtypePool>(_defaultBulletPoolPrefab);
        pool.Init(10, 40);
        Container.BindInterfacesAndSelfTo<DefaultBulletSubtypePool>().FromInstance(pool).AsTransient();

        //_ammoPool = Container.InstantiatePrefabForComponent<AmmoSubtypePool>(_defaultBulletPoolPrefab);
        //Container.BindInterfacesAndSelfTo<AmmoSubtypePool>()
        //    .FromInstance(_ammoPool).AsTransient().WhenInjectedInto<DefaultBulletMagazine>().NonLazy();
    }

    private void InstallMagazine()
    {
        DefaultBulletType type = DefaultBulletType.TestConfig;
        Container.Bind<DefaultBulletType>().FromInstance(type).AsTransient()
            .WhenInjectedInto<DefaultBulletMagazine>().NonLazy();

        Container.BindInstance(_config).AsSingle();

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
