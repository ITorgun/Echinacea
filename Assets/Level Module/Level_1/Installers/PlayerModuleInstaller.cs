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
        [SerializeField] private PlayerModel _model;

        private Player _player;

        public override void InstallBindings()
        {
            InstallMovement();
            InstallPlayer();
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

        private void InstallMovement()
        {
            Container.BindInterfacesAndSelfTo<DefaultPlayerMover>().AsSingle().NonLazy();
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