using UnityEngine;
using Zenject;
using Assets.PlayerModule;

namespace Assets.Level_1.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Dekstop _dekstop;
        [SerializeField] private Player _prefab;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private ShotPosition _shotPosition;

        private Player _player;

        public override void InstallBindings()
        {
            InstallInput();
            InstallPlayer();
            InstallMovement();
            InstallShotPosition();
            InstallInputMediator();
        }

        private void InstallInput()
        {
            Container.BindInstance(new InputActions()).AsSingle().NonLazy();
            Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstop);
            Container.BindInterfacesAndSelfTo<Dekstop>().FromInstance(dekstop).AsSingle().NonLazy();
        }

        private void InstallPlayer()
        {
            _player = Container.InstantiatePrefabForComponent<Player>(_prefab);
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player).AsSingle().NonLazy();
        }

        private void InstallMovement()
        {
            PlayerMovement playerMovement = Container.InstantiatePrefabForComponent<PlayerMovement>(_movement, _player.transform);
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromInstance(playerMovement).AsSingle().NonLazy();
            playerMovement.Init(_player.transform);
        }

        private void InstallShotPosition()
        {
            ShotPosition shotPosition = Container.InstantiatePrefabForComponent<ShotPosition>(_shotPosition, _player.transform);
            Container.BindInterfacesAndSelfTo<ShotPosition>().FromInstance(shotPosition).AsSingle().NonLazy();
        }

        private void InstallInputMediator()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle().NonLazy();
        }
    }
}