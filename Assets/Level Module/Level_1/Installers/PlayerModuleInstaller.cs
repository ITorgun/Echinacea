using UnityEngine;
using Zenject;
using Assets.PlayerModule;
using Cinemachine;
using Assets.Player_Module.Scripts;
using Assets.Weapon_Module.Gun_Module.Gun;
using System;

namespace Assets.Level_1.Installers
{
    public class PlayerModuleInstaller : MonoInstaller
    {
        [SerializeField] private Player _prefab;
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerModel _model;

        private Player _player;

        public override void InstallBindings()
        {
            InstallMover();
            InstallPlayer();
            //InstallMovement();
            InstallCameraFollow();
            InstallModel();
            InstallInputMediator();

        }

        private void InstallPlayer()
        {
            _player = Container.InstantiatePrefabForComponent<Player>(_prefab);

            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player).AsSingle();
        }

        private void InstallCameraFollow()
        {
            _camera.Follow = _player.transform;
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
            PlayerModel playerModel = Container.InstantiatePrefabForComponent<PlayerModel>(_model, _player.transform);
            Container.BindInterfacesAndSelfTo<PlayerModel>().FromInstance(playerModel).AsSingle().NonLazy();
        }

        private void InstallInputMediator()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle().NonLazy();
        }
    }
}