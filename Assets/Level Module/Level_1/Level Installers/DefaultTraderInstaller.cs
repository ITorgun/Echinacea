using Assets.Money_Module.Trader;
using UnityEngine;
using Zenject;

public class DefaultTraderInstaller : MonoInstaller
{
    [SerializeField] private DefaultFirstLevelTrader _trader;
    [SerializeField] private TraderPanel _traderPanel;
    [SerializeField] private RectTransform _canvasTransform;
    [SerializeField] private DefaultTraderMediator _mediator;

    public override void InstallBindings()
    {
        InstallTraderPanel();
        InstallTrader();
        InstallMediator();
    }

    private void InstallTraderPanel()
    {
        TraderPanel panel = Container.InstantiatePrefabForComponent<TraderPanel>(_traderPanel, _canvasTransform);
        Container.BindInterfacesAndSelfTo<TraderPanel>().FromInstance(panel).AsSingle();
    }

    private void InstallTrader()
    {
        IDefaultTrader trader = Container.InstantiatePrefabForComponent<IDefaultTrader>(_trader);
        Container.BindInterfacesAndSelfTo<IDefaultTrader>().FromInstance(trader).AsSingle()
            .WhenInjectedInto<DefaultTraderMediator>();
    }

    private void InstallMediator()
    {
        DefaultTraderMediator mediator = Container.InstantiatePrefabForComponent<DefaultTraderMediator>(_mediator);
        Container.BindInterfacesAndSelfTo<DefaultTraderMediator>().FromInstance(mediator).AsSingle();
    }
}
