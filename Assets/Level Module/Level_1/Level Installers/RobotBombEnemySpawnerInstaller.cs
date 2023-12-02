using Assets.Enemy_Module.EnemyDiedScoreWeight;
using Assets.EnemyModule.Grounded.RobotBomb;
using UnityEngine;
using Zenject;

namespace Assets.LevelModule.Level_1
{
    public class RobotBombEnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private RobotBombEnemyPool _enemyPool;
        [SerializeField] private RobotBombEnemySpawner _spawner;

        public override void InstallBindings()
        {
            InstallFacrory();
            InstallPool();
            InstallDiedScore();
            InstallSpawner();
        }

        private void InstallFacrory()
        {
            Container.BindInterfacesAndSelfTo<RobotBombEnemyFactory<RobotBombEnemy>>().AsSingle().NonLazy();
        }

        private void InstallPool()
        {
            Container.BindInterfacesAndSelfTo<RobotBombEnemyPool>().FromComponentInNewPrefab(_enemyPool).AsSingle();
        }

        private void InstallDiedScore()
        {
            Container.BindInterfacesAndSelfTo<EnemyDiedScoreCalculator>()
                .AsSingle()
                .WithArguments(200)
                .WhenInjectedInto<RobotBombEnemySpawner>();
        }

        private void InstallSpawner()
        {
            RobotBombEnemySpawner spawner = Container.InstantiatePrefabForComponent<RobotBombEnemySpawner>(_spawner);
            Container.BindInterfacesAndSelfTo<RobotBombEnemySpawner>().FromInstance(spawner).AsSingle();
        }
    }
}