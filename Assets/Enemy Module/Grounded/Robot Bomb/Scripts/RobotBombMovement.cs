using UnityEngine;
using Zenject;
using Assets.PlayableEntityModule.Mover;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombMovement : MonoBehaviour, IMovement
    {
        public IMover Mover { get; private set; }

        [Inject]
        public void Constructor(IMover mover)
        {
            Mover = mover;
        }

        private void Start()
        {
            Mover.StartMove();
        }

        private void Update()
        {
            Mover.Moving(transform);
        }
    }
}