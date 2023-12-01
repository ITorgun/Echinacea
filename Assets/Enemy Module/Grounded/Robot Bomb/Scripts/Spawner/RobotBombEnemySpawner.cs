using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb
{
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
                RobotBombEnemy robotBombEnemy = _factory.GetRobotBombEnemy(transform);
                robotBombEnemy.transform.position = transform.position + new Vector3(0, Random.Range(1, 10));
                _enemies.Add(robotBombEnemy);
                yield return new WaitForSeconds(2);
            }
        }
    }
}