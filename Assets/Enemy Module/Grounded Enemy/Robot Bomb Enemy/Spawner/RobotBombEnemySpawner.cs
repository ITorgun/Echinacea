using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RobotBombEnemySpawner : MonoBehaviour
{
    private RobotBombEnemyFactory _factory;

    [Inject]
    public void Constructor(RobotBombEnemyFactory factory)
    {
        _factory = factory;
    }

    private void Start()
    {
        //_factory.GetRobotBombEnemy(transform);
        //_factory.GetRobotBombEnemy(transform);
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            _factory.GetRobotBombEnemy(transform);

            yield return new WaitForSeconds(5);
        }
    }
}
