using UnityEngine;
using Zenject;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb
{

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
            RobotBombEnemy enemyObject = _container.InstantiatePrefabForComponent<RobotBombEnemy>(_config.Prefab, enemyTranform);
            return enemyObject;
        }

        private RobotBombEnemyConfig GetConfig()
        {
            return Resources.Load<RobotBombEnemyConfig>(ConfigsPath);
        }
    }
}