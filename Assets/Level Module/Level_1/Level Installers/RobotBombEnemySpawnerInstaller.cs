using Assets.Enemy_Module.Grounded.Robot_Bomb.Configs;
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
            Container.BindInterfacesAndSelfTo<RobotBombEnemyPool>().FromComponentInNewPrefab(_enemyPool).AsSingle();

            Container.BindInterfacesAndSelfTo<RobotBombEnemyFactory<RobotBombEnemy>>().AsSingle().NonLazy();

            RobotBombEnemySpawner spawner = Container.InstantiatePrefabForComponent<RobotBombEnemySpawner>(_spawner);
            Container.BindInterfacesAndSelfTo<RobotBombEnemySpawner>().FromInstance(spawner).AsSingle();
        }
    }
}