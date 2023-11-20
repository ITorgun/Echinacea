using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private Dekstop _dekstop;

    public override void InstallBindings()
    {
        InstallInput();
    }

    private void InstallInput()
    {
        Container.BindInstance(new InputActions()).AsSingle().NonLazy();
        Dekstop dekstop = Container.InstantiatePrefabForComponent<Dekstop>(_dekstop);
        Container.BindInterfacesAndSelfTo<Dekstop>().FromInstance(dekstop).AsSingle().NonLazy();
    }
}