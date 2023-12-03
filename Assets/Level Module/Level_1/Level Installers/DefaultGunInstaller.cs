using Assets.Weapon_Module.Gun_Module.Gun;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

namespace Assets.LevelModule.Level_1
{
    public class DefaultGunInstaller : MonoInstaller
    {
        [SerializeField] private AmmoSubtypePool _defaultBulletPoolPrefab;
        [SerializeField] private DefaultGun _defaultGunPrefab;
        [SerializeField] private DefaultMagazineConfig _config;

        private PlayerGunInventory _gunInventory;

        private DefaultGun _gun;

        [Inject]
        public void Constructor(PlayerGunInventory gunInventory)
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
                .FromInstance(_gun).AsTransient().NonLazy();
        }
    }
}