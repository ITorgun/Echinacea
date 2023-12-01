using UnityEngine;
using Assets.Playable_Entity_Module.Movement.Mover;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb
{
    [CreateAssetMenu(fileName = "Robot Bomb Enemy Config", menuName = "SO/RobotBombEnemyConfig")]
    public class RobotBombEnemyConfig : ScriptableObject, IMoverConfig
    {
        [SerializeField] private RobotBombEnemy _prefab;

        public float RadiusFinder => Random.Range(4, 7);
        public float Cooldown => Random.Range(0, 5);
        public float MoverSpeed => Random.Range(1, 5);
        public float BombDamage => Random.Range(10, 50);

        public RobotBombEnemy Prefab => _prefab;
    }
}