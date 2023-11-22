using Assets.Player_Module.UI;
using UnityEngine;
using Zenject;

public class PlayerMediatorsInstaller : MonoInstaller
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private PlayerMediator _playerMediator;
    [SerializeField] private PlayerHealthViewer _playerHealthViewer;

    public override void InstallBindings()
    {
        InstantiateHealthViewer();

        InstallViewerMediator();
        InstallInputMediator();
        InstallPlayerMediator();
    }

    private void InstantiateHealthViewer()
    {
        PlayerHealthViewer healthViewer = Container
            .InstantiatePrefabForComponent<PlayerHealthViewer>(_playerHealthViewer, _rectTransform);

        Container.BindInterfacesAndSelfTo<PlayerHealthViewer>().FromInstance(healthViewer).AsSingle();
    }

    private void InstallViewerMediator()
    {
        Container.BindInterfacesAndSelfTo<PlayerViewerMediator>().AsSingle();
    }

    private void InstallInputMediator()
    {
        Container.BindInterfacesAndSelfTo<PlayerInputMediator>().AsSingle().NonLazy();
    }

    private void InstallPlayerMediator()
    {
        PlayerMediator mediator = Container.InstantiatePrefabForComponent<PlayerMediator>(_playerMediator);
        Container.BindInterfacesAndSelfTo<PlayerMediator>().FromInstance(mediator).AsSingle().NonLazy();
    }
}
