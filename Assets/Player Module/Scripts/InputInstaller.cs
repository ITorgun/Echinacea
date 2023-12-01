using Assets.InputModule;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private Dekstop _dekstopPrefab;
    [SerializeField] private ShotPosition _shotPositionPrefab;

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
        ShotPosition shotPosition = Container.InstantiatePrefabForComponent<ShotPosition>(_shotPositionPrefab);
        Container.BindInterfacesAndSelfTo<ShotPosition>().FromInstance(shotPosition).AsSingle().NonLazy();
    }
}