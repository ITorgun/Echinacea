using Assets.EnemyModule.Grounded.RobotBomb;
using Assets.EnemyModule.PlayerFinder;
using Assets.PlayableEntityModule.Finder;
using Assets.PlayableEntityModule.Mover;
using UnityEngine;
using Zenject;

namespace Assets.LevelModule.Level_1
{
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
}