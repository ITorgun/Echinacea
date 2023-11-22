using UnityEngine;
using Zenject;
using Assets.PlayerModule;
using Cinemachine;
using Assets.Player_Module.Scripts;
using Assets.Weapon_Module.Gun_Module.Gun;

namespace Assets.Level_1.Installers
{
    public class PlayerModuleInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerGameObjectPrefab;
        [SerializeField] private CinemachineVirtualCamera _cameraPrefab;
        [SerializeField] private PlayerModel _modelPrefab;
        [SerializeField] private PlayerInventory _playerInventoryPrefab;
        [SerializeField] private GunInventory _gunInventoryPrefab;
        [SerializeField] private PlayerAttack _playerAttackPrefab;
        [SerializeField] private ShotPosition _shotPositionPrefab;

        private ShotPosition _shotPosition;
        private StrongGun _strongGun;

        private GameObject _playerGameObject;
        private GunInventory _gunInventory;

        [Inject]
        public void Constructor(ShotPosition shotPosition, StrongGun strongGun)
        {
            _shotPosition = shotPosition;
            _strongGun = strongGun;
        }

        public override void InstallBindings()
        {
            InstantiatePlayerGameobject();
            SetCameraFollow();

            InstallModel();

            InstallPlayerAttack();

            InstallHealth();

            InstallMover();
            InstallMovement();

            InstallBulletInventory();
            InstallGunInventory();
            InstallPlayerInventory();

            InstallPlayer();

            InstallInputMediator();
        }

        private void InstantiatePlayerGameobject()
        {
            _playerGameObject = Instantiate(_playerGameObjectPrefab);
        }

        private void SetCameraFollow()
        {
            _cameraPrefab.Follow = _playerGameObject.transform;
        }

        private void InstallMover()
        {
            DefaultPlayerMover mover = Container.Instantiate<DefaultPlayerMover>();
            mover.Init(10);
            Container.BindInterfacesAndSelfTo<DefaultPlayerMover>().FromInstance(mover).AsSingle().NonLazy();
        }

        private void InstallModel()
        {
            PlayerModel playerModel = Container.InstantiatePrefabForComponent<PlayerModel>(_modelPrefab, _playerGameObject.transform);
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(playerModel).AsSingle().NonLazy();
        }

        private void InstallPlayerAttack()
        {
            PlayerAttack playerAttack = Container.InstantiatePrefabForComponent<PlayerAttack>(_playerAttackPrefab, _playerGameObject.transform);
            playerAttack.transform.position = _playerGameObject.transform.position;

            _shotPosition.transform.position = playerAttack.transform.position;
            _shotPosition.transform.SetParent(playerAttack.transform);

            Container.BindInterfacesAndSelfTo<PlayerAttack>()
                .FromInstance(playerAttack).AsSingle().NonLazy();
        }

        private void InstallHealth()
        {
            PlayerHealth health = Container.InstantiateComponent<PlayerHealth>(_playerGameObject);
            Container.BindInterfacesAndSelfTo<PlayerHealth>().FromInstance(health).AsTransient();
        }

        private void InstallMovement()
        {
            PlayerMovement playerMovement = Container.InstantiateComponent<PlayerMovement>(_playerGameObject);
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(playerMovement).AsSingle();
        }

        private void InstallBulletInventory()
        {
            Container.Bind<BulletInventory>().AsSingle().NonLazy();
        }

        private void InstallGunInventory()
        {
            _gunInventory = Container.InstantiatePrefabForComponent<GunInventory>(_gunInventoryPrefab, _playerGameObject.transform);
            _gunInventory.transform.position = _playerGameObject.transform.position;

            _strongGun.transform.position = _gunInventory.transform.position;
            _strongGun.transform.SetParent(_gunInventory.transform);

            Container.BindInterfacesAndSelfTo<GunInventory>().FromInstance(_gunInventory)
                .AsSingle().NonLazy();
        }

        private void InstallPlayerInventory()
        {
            PlayerInventory playerInventory = Container.InstantiatePrefabForComponent<PlayerInventory>(_playerInventoryPrefab, _playerGameObject.transform);
            playerInventory.transform.position = _playerGameObject.transform.position;

            _gunInventory.transform.position = playerInventory.transform.position;
            _gunInventory.transform.SetParent(playerInventory.transform);

            Container.BindInterfacesAndSelfTo<PlayerInventory>().FromInstance(playerInventory).AsSingle().NonLazy();
        }

        private void InstallPlayer()
        {
            Player player = Container.InstantiateComponent<Player>(_playerGameObject);
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
        }

        private void InstallInputMediator()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle().NonLazy();
        }
    }
}