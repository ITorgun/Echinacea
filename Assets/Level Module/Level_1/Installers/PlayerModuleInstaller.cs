using UnityEngine;
using Zenject;
using Assets.PlayerModule;
using Cinemachine;
using Assets.Player_Module.Scripts;

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
            InstallPlayer();
            InstallMover();
            InstallMovement();
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
            Container.BindInterfacesAndSelfTo<DefaultPlayerMover>().AsSingle().NonLazy();
        }

        private void InstallMovement()
        {
            PlayerMovement movement = Container.InstantiatePrefabForComponent<PlayerMovement>(_playerMovement, _player.transform);
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(movement).AsSingle().NonLazy();
        }

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