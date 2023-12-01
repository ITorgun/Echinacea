using Assets.Enemy_Module.Grounded.Robot_Bomb;
using UnityEngine;
using Zenject;

public class RobotBombEnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private RobotBombEnemySpawner _spawner;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<RobotBombEnemyFactory>().AsSingle().NonLazy();

        RobotBombEnemySpawner spawner = Container.InstantiatePrefabForComponent<RobotBombEnemySpawner>(_spawner);
        Container.BindInterfacesAndSelfTo<RobotBombEnemySpawner>().FromInstance(spawner).AsSingle();
    }
}
