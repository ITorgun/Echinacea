using Assets.Enemy_Module.Grounded_Enemy;
using UnityEngine;
using Zenject;

public class RobotBombEnemyFactory
{
    private const string ConfigsPath = "RobotBombEnemyConfigs/FreqiencyAroundContactEnemy";

    private DiContainer _container;

    private RobotBombEnemyConfig _config;

    public RobotBombEnemyFactory(DiContainer container)
    {
        _container = container;

        _config = GetConfig();
    }

    public RobotBombEnemy GetRobotBombEnemy(Transform enemyTranform)
    {
        RobotBombEnemyConfig config = GetConfig();

        GameObject enemyObject = _container.InstantiatePrefab(config.Prefab, enemyTranform);
        InstallMovement(enemyObject);
        RobotBombEnemy enemy = InstallEnemy(enemyObject);
        InstallRobotBomb(enemy, config);
        return enemy;
    }

    public RobotBombEnemy GetRobotBombEnemy2(Transform enemyTranform)
    {
        RobotBombEnemy enemyObject = _container.InstantiatePrefabForComponent<RobotBombEnemy>(_config.TestPrefab, enemyTranform);
        return enemyObject;
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
