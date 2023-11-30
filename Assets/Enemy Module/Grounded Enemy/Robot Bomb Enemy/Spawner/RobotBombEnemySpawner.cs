using Assets.Enemy_Module.Grounded_Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RobotBombEnemySpawner : MonoBehaviour
{
    private RobotBombEnemyFactory _factory;
    private List<RobotBombEnemy> _enemies;

    [Inject]
    public void Constructor(RobotBombEnemyFactory factory)
    {
        _factory = factory;
        _enemies = new List<RobotBombEnemy>();
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            RobotBombEnemy robotBombEnemy = _factory.GetRobotBombEnemy2(transform);
            robotBombEnemy.transform.position = transform.position + new Vector3(0, Random.Range(1, 10));
            _enemies.Add(robotBombEnemy);
            yield return new WaitForSeconds(2);
        }
    }
}
