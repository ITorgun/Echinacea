using Assets.Enemy_Module.Grounded_Enemy;
using System.Collections;
using System.Collections.Generic;
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
