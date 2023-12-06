using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

namespace Assets.LevelModule.Level_1
{
    public class StrongGunInstaller : MonoInstaller
    {
        [SerializeField] private AmmoSubtypePool _bulletPoolPrefab;
        [SerializeField] private StrongGun _gunPrefab;
        [SerializeField] private StrongMagazineConfig _config;

        private StrongGun _gun;

        public override void InstallBindings()
        {
            InstallBulletFactory();
            InstallBulletPool();
            InstallMagazine();
            InstallGun();
        }

        private void InstallBulletFactory()
        {
            Container.BindInterfacesAndSelfTo<BulletFactory>().AsSingle().NonLazy();
        }

        private void InstallBulletPool()
        {
            StrongBulletType type = StrongBulletType.ShortLife;
            Container.Bind<StrongBulletType>().FromInstance(type).AsTransient()
                .WhenInjectedInto<StrongBulletSubtypePool>().NonLazy();

            StrongBulletSubtypePool pool = Container.InstantiatePrefabForComponent<StrongBulletSubtypePool>(_bulletPoolPrefab);
            pool.Init(10, 60);
            Container.BindInterfacesAndSelfTo<StrongBulletSubtypePool>().FromInstance(pool).AsTransient();
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
                .FromInstance(_gun).AsTransient().NonLazy();
        }
    }
}