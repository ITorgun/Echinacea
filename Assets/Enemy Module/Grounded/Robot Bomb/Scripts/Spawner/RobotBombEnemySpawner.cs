using Assets.Enemy_Module.EnemyDiedScoreWeight;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombEnemySpawner : MonoBehaviour
    {
        private readonly float Frequency = 2;

        private RobotBombEnemyPool _pool;
        private EnemyDiedScoreCalculator _diedScoreCalculator;


        [Inject]
        public void Constructor(RobotBombEnemyPool factory, EnemyDiedScoreCalculator diedScoreWeight)
        {
            _pool = factory;
            _pool.transform.SetParent(transform);

            _diedScoreCalculator = diedScoreWeight;
        }

        private void OnEnable()
        {
            StartCoroutine(Spawning());
        }

        private void OnDisable()
        {
            _pool.ClearPool();
        }

        private IEnumerator Spawning()
        {
            Vector3 randomPosition;

            while (_diedScoreCalculator.IsSumLimited == false)
            {
                randomPosition = new Vector3(Random.Range(1, 4), Random.Range(1, 10));
                RobotBombEnemy enemy = _pool.Get(randomPosition);
                enemy.Died += OnEnemyDied;
                yield return new WaitForSeconds(Frequency);
            }

            Debug.Log("Win!");
        }

        private void OnEnemyDied(RobotBombEnemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            _diedScoreCalculator.Visit(enemy);
            Debug.Log("Sum: " + _diedScoreCalculator.Sum);
        }
    }
}