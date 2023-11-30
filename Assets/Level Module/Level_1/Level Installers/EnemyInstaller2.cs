using Assets.Enemy_Module.Grounded_Enemy;
using Assets.Enemy_Module.Interfaces;
using Assets.Enemy_Module.PlayerFinder;
using Assets.Enemy_Module;
using Assets.Playable_Entity_Module.Mover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using Assets.Playable_Entity_Module;

namespace Assets.Level_Module.Level_1.Level_Installers
{
    public class EnemyInstaller2 : MonoInstaller
    {
        [SerializeField] private GameObject _enemyObjectPrefab;
        [SerializeField] private RobotBomb _robotBomb;
        [SerializeField] private Transform _spawnPoint;

        private GameObject _enemyObject;
        private RobotBombEnemy _enemy;

        public override void InstallBindings()
        {
            InstallFinder();
            InstallPositionable();
            InstallMover();
            InstallMovement();
            //InstallEnemy();
            InstallRobotBomb();
        }

        private void InstallPositionable()
        {
            //RobotPositionable robotPositionable = Container.Instantiate<RobotPositionable>();
            Container.BindInterfacesAndSelfTo<IPositionable>().AsTransient();
        }

        private void InstallFinder()
        {
            //FreqiencyAroundFinder moveToPosition = new FreqiencyAroundFinder(
            //    new AroundItselfPlayerFinder(_enemyObject.transform, 5), 1f);
            Container.BindInterfacesAndSelfTo<IFinder>()
                .AsTransient().WhenInjectedInto<RobotBombMovement>();
        }

        private void InstallMover()
        {
            //MoverToPosition moveToPosition = Container.Instantiate<MoverToPosition>();
            //moveToPosition.Init(3);
            Container.BindInterfacesAndSelfTo<IMover>()
                .AsTransient().WhenInjectedInto<MoverToPosition>();
        }

        private void InstallMovement()
        {
            //RobotBombMovement robotMovement = Container.InstantiateComponent<RobotBombMovement>(_enemyObject);
            Container.BindInterfacesAndSelfTo<IMovement>()
                .AsTransient().WhenInjectedInto<RobotBombEnemy>();
        }

        //private void InstallEnemy()
        //{
        //    _enemy = Container.InstantiateComponent<RobotBombEnemy>(_enemyObject);
        //    Container.BindInterfacesAndSelfTo<RobotBombEnemy>().FromInstance(_enemy).AsTransient();
        //}

        private void InstallRobotBomb()
        {
            //RobotBomb robotBomb = Container.InstantiatePrefabForComponent<RobotBomb>(_robotBomb, _enemy.transform);
            Container.BindInterfacesAndSelfTo<RobotBomb>()
                .AsTransient().WhenInjectedInto<RobotBombEnemy>();

            //robotBomb.Bombed += _enemy.OnBombed;
        }
    }
}