using Assets.Playable_Entity_Module.Finder;
using Assets.Playable_Entity_Module.Movement.Mover;
using UnityEngine;

namespace Assets.Playable_Entity_Module.Mover
{
    public class MoverToFindedPosition : IMover
    {
        private readonly float Offset = 0.2f;

        private IFinder _finder;
        private bool _isMoving;

        public float Speed { get; private set; }
        public float CurrentSpeed { get; set; }

        public MoverToFindedPosition(IFinder finder, IMoverConfig config)
        {
            _finder = finder;
            Speed = config.MoverSpeed;
            CurrentSpeed = Speed;

            Debug.Log(Speed);
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
