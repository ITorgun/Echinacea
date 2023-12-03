using Assets.InputModule;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private Dekstop _dekstopPrefab;
    [SerializeField] private ShootPosition _shotPositionPrefab;

    public override void InstallBindings()
    {
        InstallInput();
        InstallShotPosition();
    }

    private void InstallInput()
    {
        Container.BindInstance(new InputActions()).AsSingle().NonLazy();
        Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstopPrefab);
        Container.BindInterfacesAndSelfTo<Dekstop>().FromInstance(dekstop).AsSingle().NonLazy();
    }

    private void InstallShotPosition()
    {
        ShootPosition shotPosition = Container.InstantiatePrefabForComponent<ShootPosition>(_shotPositionPrefab);
        Container.BindInterfacesAndSelfTo<ShootPosition>().FromInstance(shotPosition).AsSingle().NonLazy();
    }
}