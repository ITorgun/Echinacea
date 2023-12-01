using Assets.Enemy_Module.Grounded.Robot_Bomb.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombEnemySpawner : MonoBehaviour
    {
        private RobotBombEnemyPool _factory;

        [Inject]
        public void Constructor(RobotBombEnemyPool factory)
        {
            _factory = factory;
            _factory.transform.SetParent(transform);
        }

        private void Start()
        {
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            Vector3 randomPosition;
            while (true)
            {
                randomPosition = new Vector3(Random.Range(1, 4), Random.Range(1, 10));
                RobotBombEnemy robotBombEnemy = _factory.Get(randomPosition);
                yield return new WaitForSeconds(2);
            }
        }
    }
}