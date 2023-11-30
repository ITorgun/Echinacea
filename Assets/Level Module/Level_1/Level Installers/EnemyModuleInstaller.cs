using Assets.Enemy_Module;
using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.Interfaces;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Playable_Entity_Module;
using Assets.Playable_Entity_Module.Mover;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class EnemyModuleInstaller : MonoInstaller
{
    [SerializeField] private GameObject _enemyObjectPrefab;
    [SerializeField] private RobotBomb _robotBomb;
    [SerializeField] private Transform _spawnPoint;

    private GameObject _enemyObject;
    private RobotBombEnemy _enemy;

    public override void InstallBindings()
    {
        InstantiateEnemyObject();

        InstallFinder();
        InstallPositionable();
        InstallMover();
        InstallMovement();
        InstallEnemy();
        InstallRobotBomb();
    }

    private void InstantiateEnemyObject()
    {
        _enemyObject = Instantiate(_enemyObjectPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    private void InstallPositionable()
    {
        RobotPositionable robotPositionable = Container.Instantiate<RobotPositionable>();
        Container.BindInterfacesAndSelfTo<RobotPositionable>().FromInstance(robotPositionable)
            .AsTransient();
    }

    private void InstallFinder()
    {
        FreqiencyAroundFinder finder = new FreqiencyAroundFinder(
            new AroundItselfPlayerFinder(5), 1f);

        Container.BindInterfacesAndSelfTo<IFinder>().FromInstance(finder)
            .AsTransient().WhenInjectedInto<RobotBombMovement>();
    }


    private void InstallMover()
    {
        MoverToPosition moveToPosition = Container.Instantiate<MoverToPosition>();
        moveToPosition.Init(3);
        Container.BindInterfacesAndSelfTo<IMover>().FromInstance(moveToPosition)
            .AsTransient().WhenInjectedInto<RobotBombMovement>();
    }
    private void InstallMovement()
    {
        RobotBombMovement robotMovement = Container.InstantiateComponent<RobotBombMovement>(_enemyObject);
        Container.BindInterfacesAndSelfTo<IMovement>().FromInstance(robotMovement)
            .AsTransient().WhenInjectedInto<RobotBombEnemy>();
    }

    private void InstallEnemy()
    {
        _enemy = Container.InstantiateComponent<RobotBombEnemy>(_enemyObject);
        Container.BindInterfacesAndSelfTo<RobotBombEnemy>().FromInstance(_enemy).AsTransient();
    }

    private void InstallRobotBomb()
    {
        RobotBomb robotBomb = Container.InstantiatePrefabForComponent<RobotBomb>(_robotBomb, _enemy.transform);
        Container.BindInterfacesAndSelfTo<RobotBomb>().FromInstance(robotBomb)
            .AsTransient().WhenInjectedInto<RobotBombEnemy>();

        robotBomb.Bombed += _enemy.OnBombed;
    }
}