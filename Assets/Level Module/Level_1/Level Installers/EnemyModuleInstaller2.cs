using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.Interfaces;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Enemy_Module;
using Assets.Playable_Entity_Module.Mover;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;
using Assets.Playable_Entity_Module;

public class EnemyModuleInstaller2 : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallFinder();
        InstallPositionable();
        InstallMover();
        InstallMovement();
        InstallEnemy();
        InstallRobotBomb();
    }

    private void InstallFinder()
    {
        Container.BindInterfacesAndSelfTo<IFinder>().AsTransient().WhenInjectedInto<RobotBombMovement>();
    }

    private void InstallPositionable()
    {
        Container.BindInterfacesAndSelfTo<IPositionable>().AsTransient();
    }

    private void InstallMover()
    {
        Container.BindInterfacesAndSelfTo<IMover>()
            .AsTransient().WhenInjectedInto<RobotBombMovement>();
    }

    private void InstallMovement()
    {
        Container.BindInterfacesAndSelfTo<IMovement>()
            .AsTransient().WhenInjectedInto<RobotBombEnemy>();
    }

    private void InstallEnemy()
    {
        Container.BindInterfacesAndSelfTo<RobotBombEnemy>().AsTransient();
    }

    private void InstallRobotBomb()
    {
        Container.BindInterfacesAndSelfTo<RobotBomb>()
            .AsTransient().WhenInjectedInto<RobotBombEnemy>();
    }
}
