using Assets.Enemy_Module.Interfaces;
using UnityEngine;

namespace Assets.Playable_Entity_Module.Mover
{
    public class MoverToPosition : IMover
    {
        private readonly float Offset = 0.2f;

        //private IPositionable _positionable;
        private IFinder _finder;
        private bool _isMoving;

        public float Speed { get; private set; }
        public float CurrentSpeed { get; private set; }

        public MoverToPosition(IFinder finder)
        {
            _finder = finder;
            Speed = 2;
        }

        public void Init(float speed)
        {
            Speed = speed;
        }

        public void StartMove()
        {
            _isMoving = true;
            _finder.StartFind();
        }

        public void StopMove() => _isMoving = false;

        public void Moving(Transform transform)
        {
            if (_isMoving == false || _finder.TryFindPosition(transform.position, out Vector2 finderPosition) == false)
            {
                return;
            }

            float distance = Vector2.Distance(transform.position, finderPosition);

            if (distance < Offset)
            {
                return;
            }

            Vector2 direction = (Vector3)finderPosition - transform.position;
            transform.Translate(Speed * Time.deltaTime * direction.normalized);
        }

        public void DebaffSpeed(float speed)
        {
            CurrentSpeed -= speed;
        }

        public void ResetSpeed()
        {
            CurrentSpeed = Speed;
        }
    }
}
