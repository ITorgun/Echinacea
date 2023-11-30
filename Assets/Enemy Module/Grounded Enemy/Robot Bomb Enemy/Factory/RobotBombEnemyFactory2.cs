using Assets.Enemy_Module;
using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Playable_Entity_Module.Mover;
using UnityEngine;
using Zenject;

public class RobotBombEnemyFactory2 : MonoBehaviour
{
    private const string ConfigsPath = "RobotBombEnemyConfigs/FreqiencyAroundContactEnemy";

    private DiContainer _container;

    //public RobotBombEnemyFactory2(DiContainer container)
    //{
    //    _container = container;
    //}

    //private RobotBombEnemyConfig GetConfig()
    //{
    //    return Resources.Load<RobotBombEnemyConfig>(ConfigsPath);
    //}

    //public RobotBombEnemy GetRobotBombEnemy(Transform enemyTranform)
    //{
    //    RobotBombEnemyConfig config = GetConfig();

    //    GameObject enemyObject = _container.InstantiatePrefab(config.Prefab, enemyTranform);

    //    FreqiencyAroundFinder finder = new FreqiencyAroundFinder(
    //        new AroundItselfPlayerFinder(enemyObject.transform, 5), 1f);

    //    MoverToPosition moveToPosition = _container.Instantiate<MoverToPosition>();
    //    moveToPosition.Init(3);

    //    RobotBombMovement robotMovement = _container.InstantiateComponent<RobotBombMovement>(enemyObject);

    //    RobotBombEnemy enemy = _container.InstantiateComponent<RobotBombEnemy>(enemyObject);

    //    RobotBomb robotBomb = _container.InstantiatePrefabForComponent<RobotBomb>(config.RobotBomb, enemyTranform);

    //    robotBomb.Bombed += enemy.OnBombed;
    //    return enemy;
    //}
}