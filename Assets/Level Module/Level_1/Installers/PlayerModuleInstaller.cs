using UnityEngine;
using Zenject;
using Assets.PlayerModule;
using Cinemachine;
using Assets.Player_Module.Scripts;
using Assets.Weapon_Module.Gun_Module.Gun;
using System;
using System.ComponentModel;

namespace Assets.Level_1.Installers
{
    public class PlayerModuleInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerInstance;
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerModel _model;

        
        //[SerializeField] private PlayerInventory _playerInventory;

        [SerializeField] private GunInventory _gunInventory;
        [SerializeField] private PlayerAttack _playerAttack;

        [SerializeField] private ShotPosition _shotPosition;

        [SerializeField] private Player _player;

        private GameObject _playerGameobject;

        [Inject]
        private ShotPosition ShotPositionInstance { get; set; }

        [Inject]
        public StrongGun StrongGun { get; set; }

        public override void InstallBindings()
        {
            InstallMover();
            InstantiatePlayerGameobject();
            //InstallMovement();
            InstallCameraFollow();
            InstallModel();

            InstallPlayerAttack();
            GunInventoryInstaller();
            //PlayerInventoryInstaller();

            PlayerMovement playerMovement = Container.InstantiateComponent<PlayerMovement>(_playerGameobject);
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(playerMovement).AsSingle();

            Player player = Container.InstantiateComponent<Player>(_playerGameobject);
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();

            InstallInputMediator();

        }

        private void InstantiatePlayerGameobject()
        {
            _playerGameobject = Instantiate(_playerInstance);
        }

        private void InstallCameraFollow()
        {
            _camera.Follow = _playerGameobject.transform;
        }

        private void InstallMover()
        {
            DefaultPlayerMover mover = Container.Instantiate<DefaultPlayerMover>();
            mover.Init(10);
            Container.BindInterfacesAndSelfTo<DefaultPlayerMover>().FromInstance(mover).AsSingle().NonLazy();
        }

        //private void InstallMovement()
        //{
        //    PlayerMovement movement = Container.InstantiatePrefabForComponent<PlayerMovement>(_playerMovement, _player.transform);
        //    Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(movement).AsSingle().NonLazy();
        //}

        private void InstallModel()
        {
            PlayerModel playerModel = Container.InstantiatePrefabForComponent<PlayerModel>(_model, _playerGameobject.transform);
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(playerModel).AsSingle().NonLazy();
        }

        private void InstallPlayerAttack()
        {
            PlayerAttack playerAttack = Container.InstantiatePrefabForComponent<PlayerAttack>(_playerAttack, _playerGameobject.transform);
            playerAttack.transform.position = _playerGameobject.transform.position;

            ShotPositionInstance.transform.position = playerAttack.transform.position;
            ShotPositionInstance.transform.SetParent(playerAttack.transform);

            Container.BindInterfacesAndSelfTo<PlayerAttack>()
                .FromInstance(playerAttack).AsSingle().NonLazy();
        }

        private void GunInventoryInstaller()
        {
            GunInventory gunInventory = Container.InstantiatePrefabForComponent<GunInventory>(_gunInventory, _playerGameobject.transform);
            gunInventory.transform.position = _playerGameobject.transform.position;

            StrongGun.transform.position = gunInventory.transform.position;
            StrongGun.transform.SetParent(gunInventory.transform);

            Container.BindInterfacesAndSelfTo<GunInventory>().FromInstance(gunInventory).AsSingle().NonLazy();
        }

        //private void PlayerInventoryInstaller()
        //{
        //    PlayerInventory playerInventory = Container.InstantiatePrefabForComponent<PlayerInventory>(_playerInventory, Player.transform);
        //    playerInventory.transform.position = Player.transform.position;

        //    Container.BindInterfacesAndSelfTo<PlayerInventory>().FromInstance(playerInventory).AsSingle().NonLazy();
        //}

        private void InstallInputMediator()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle().NonLazy();
        }
    }
}