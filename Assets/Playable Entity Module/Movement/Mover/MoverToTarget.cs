using UnityEngine;

namespace Assets.PlayableEntityModule.Mover
{
    class MoverToTarget : IMover
    {
        private ITargetable _targetable;
        private IMovable _movable;

        private bool _isMoving;

        public float Speed { get; private set; }
        public float CurrentSpeed { get; set; }

        public MoverToTarget(IMovable movable, ITargetable targetable)
        {
            _movable = movable;
            _targetable = targetable;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Moving(Transform transform)
        {
            if (_isMoving == false)
            {
                return;
            }

            if (Vector3.Distance(transform.position, _targetable.TargetTransform.position) < 0.2f)
            {
                return;
            }

            Vector3 direction = _targetable.TargetTransform.position - transform.position;
            transform.Translate(_movable.Speed * Time.deltaTime * direction.normalized);
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
