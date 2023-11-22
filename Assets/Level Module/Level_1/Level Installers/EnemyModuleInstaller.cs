using Assets.Enemy_Module;
using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Playable_Entity_Module;
using Assets.Playable_Entity_Module.IMover;
using UnityEngine;
using Zenject;

public class EnemyModuleInstaller : MonoInstaller
{
    [SerializeField] private RobotBombEnemy _enemyPrefab;
    [SerializeField] private RobotBomb _robotBomb;
    [SerializeField] private Transform _spawnPoint;

    private RobotBombEnemy _enemy;

    public override void InstallBindings()
    {
        InstantiateEnemy();
        InstallFinder();
        InstallPositionable();
        InstallMover();
        InstallRobotBomb();
    }

    private void InstantiateEnemy()
    {
        _enemy = Container.InstantiatePrefabForComponent<RobotBombEnemy>(_enemyPrefab);
        _enemy.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);

        Container.Bind<IMovable>().FromInstance(_enemy).WhenInjectedInto<MoverToPosition>();
        Container.Inject(_enemy);

        Container.Bind<RobotBombEnemy>().FromInstance(_enemy).AsTransient();
    }

    private void InstallFinder()
    {
        FreqiencyAroundFinder moveToPosition = new FreqiencyAroundFinder(
            new AroundItselfPlayerFinder(_enemy.transform, 5), 0);
        _enemy.InjectFinder(moveToPosition);
    }

    private void InstallMover()
    {
        MoverToPosition moveToPosition = Container.Instantiate<MoverToPosition>();
        //Container.Bind<IMover>().FromInstance(moveToPosition).AsTransient();
        _enemy.InjectMover(moveToPosition);
    }

    private void InstallPositionable()
    {
        RobotPositionable robotPositionable = Container.Instantiate<RobotPositionable>();
        Container.BindInterfacesAndSelfTo<RobotPositionable>().FromInstance(robotPositionable).AsSingle().WhenInjectedInto<MoverToPosition>();
        _enemy.InjectTarget(robotPositionable);
    }

    private void InstallRobotBomb()
    {
        RobotBomb robotBomb = Container.InstantiatePrefabForComponent<RobotBomb>(_robotBomb, _enemy.transform);
        Container.BindInterfacesAndSelfTo<RobotBomb>().FromInstance(robotBomb)
            .AsTransient().WhenInjectedInto<RobotBombEnemy>();

        robotBomb.Bombed += _enemy.OnBombed;
    }
}
