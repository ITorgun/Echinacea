using UnityEngine;
using Zenject;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombEnemyPool : MonoBehaviour
    {
        private QueueGenericPool<RobotBombEnemy> _pool;
        private RobotBombEnemyFactory<RobotBombEnemy> _factory;

        [Inject]
        public void Construct(RobotBombEnemyFactory<RobotBombEnemy> factory)
        {
            _factory = factory;

            _pool = new QueueGenericPool<RobotBombEnemy>(Create, OnGetting, OnReleasing);
        }

        public RobotBombEnemy Get(Vector2 position)
        {
            RobotBombEnemy element = _pool.Get();

            element.transform.parent = transform;
            element.transform.position = position;

            return element;
        }

        public void ClearPool()
        {
            _pool.ClearPool();
        }

        private RobotBombEnemy Create()
        {
            return _factory.GetRobotBombEnemy(transform);
        }

        private void OnGetting(RobotBombEnemy enemy)
        {
            enemy.gameObject.SetActive(true);
            enemy.Died += _pool.Release;
        }

        private void OnReleasing(RobotBombEnemy enemy)
        {
            enemy.Hide();
            enemy.Died -= _pool.Release;
        }
    }
}