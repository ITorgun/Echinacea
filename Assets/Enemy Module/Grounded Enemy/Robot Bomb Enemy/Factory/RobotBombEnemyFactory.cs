using Assets.Enemy_Module;
using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.Interfaces;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Playable_Entity_Module.Mover;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class RobotBombEnemyFactory
{
    private const string ConfigsPath = "RobotBombEnemyConfigs/FreqiencyAroundContactEnemy";

    private DiContainer _container;

    public RobotBombEnemyFactory(DiContainer container)
    {
        _container = container;
    }

    public RobotBombEnemy GetRobotBombEnemy(Transform enemyTranform)
    {
        RobotBombEnemyConfig config = GetConfig();

        GameObject enemyObject = _container.InstantiatePrefab(config.Prefab, enemyTranform);
        //enemyObject.name = "Enemy123";
        InstallMovement(enemyObject);
        RobotBombEnemy enemy = InstallEnemy(enemyObject);
        InstallRobotBomb(enemy, config);
        return enemy;
    }

    private RobotBombEnemyConfig GetConfig()
    {
        return Resources.Load<RobotBombEnemyConfig>(ConfigsPath);
    }

    private void InstallMovement(GameObject gameObject)
    {
        RobotBombMovement robotMovement = _container.InstantiateComponent<RobotBombMovement>(gameObject);
    }

    private RobotBombEnemy InstallEnemy(GameObject gameObject)
    {
        RobotBombEnemy enemy = _container.InstantiateComponent<RobotBombEnemy>(gameObject);
        return enemy;
    }

    private void InstallRobotBomb(RobotBombEnemy enemy, RobotBombEnemyConfig config)
    {
        RobotContactBomb robotBomb = _container.InstantiatePrefabForComponent<RobotContactBomb>(config.RobotBomb, enemy.transform);
        robotBomb.Init(config.BombDamage);
        //_container.BindInterfacesAndSelfTo<RobotContactBomb>()
        //    .AsTransient().WhenInjectedInto<RobotBombEnemy>();
        robotBomb.Bombed += enemy.OnBombed;
    }
}
