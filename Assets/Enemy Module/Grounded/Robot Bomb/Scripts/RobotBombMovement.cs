using UnityEngine;
using Zenject;
using Assets.Playable_Entity_Module.Mover;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb
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