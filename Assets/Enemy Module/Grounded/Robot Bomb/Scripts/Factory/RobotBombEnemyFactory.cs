using UnityEngine;
using Zenject;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombEnemyFactory<T> where T : RobotBombEnemy
    {
        private const string ConfigsPath = "RobotBombEnemyConfigs/FreqiencyAroundContactEnemy";

        private DiContainer _container;
        private RobotBombEnemyConfig _config;

        public RobotBombEnemyFactory(DiContainer container)
        {
            _container = container;

            _config = GetConfig();
        }

        public T GetRobotBombEnemy(Transform enemyTranform)
        {
            T enemyObject = _container.InstantiatePrefabForComponent<T>(_config.Prefab, enemyTranform);
            return enemyObject;
        }

        private RobotBombEnemyConfig GetConfig()
        {
            return Resources.Load<RobotBombEnemyConfig>(ConfigsPath);
        }
    }
}