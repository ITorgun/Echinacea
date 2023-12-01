using Assets.Enemy_Module.Grounded.Robot_Bomb;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Playable_Entity_Module.Finder;
using Assets.Playable_Entity_Module.Mover;
using UnityEngine;
using Zenject;

public class RobotBombEnemyInstaller : MonoInstaller
{
    [SerializeField] private RobotBombEnemyConfig _config;

    public override void InstallBindings()
    {
        InstallFinder();
        InstallMover();
    }

    private void InstallFinder()
    {
        Container.BindInterfacesAndSelfTo<IFinder>()
            .FromMethod(injectContext => new FreqiencyAroundPlayerFinder(new AroundItselfPlayerFinder(_config.RadiusFinder), _config.Cooldown))
            .AsTransient()
            .WhenInjectedInto<MoverToFindedPosition>();
    }

    private void InstallMover()
    {
        Container.BindInterfacesAndSelfTo<MoverToFindedPosition>()
            .AsTransient()
            .WithArguments(_config)
            .WhenInjectedInto<RobotBombMovement>()
            .NonLazy();
    }
}