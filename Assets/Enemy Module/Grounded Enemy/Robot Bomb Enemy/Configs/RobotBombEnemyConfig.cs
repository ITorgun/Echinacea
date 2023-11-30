using Assets.Enemy_Module.Grounded_Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "Robot Bomb Enemy Config", menuName = "SO/RobotBombEnemyConfig")]
public class RobotBombEnemyConfig : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _radiusFinder;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _moverSpeed;
    [SerializeField] private RobotBomb _robotBomb;
    [SerializeField] private float _bombDamage;

    public GameObject Prefab => _prefab;
    public float RadiusFinder => _radiusFinder;
    public float Cooldown => _cooldown; 
    public float MoverSpeed => _moverSpeed;
    public RobotBomb RobotBomb => _robotBomb;
    public float BombDamage => _bombDamage;

}
