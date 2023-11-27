using UnityEngine;

namespace Assets.Playable_Entity_Module.Mover
{
    public class MoverToPosition : IMover
    {
        private readonly float Offset = 0.2f;

        private IPositionable _positionable;
        private bool _isMoving;

        public float Speed { get; private set; }
        public float CurrentSpeed { get; private set; }

        public MoverToPosition(IPositionable positionable)
        {
            _positionable = positionable;
        }

        public void Init(float speed)
        {
            Speed = speed;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Moving(Transform transform)
        {
            if (_isMoving == false || _positionable.IsPositionSet == false)
            {
                return;
            }

            float distance = Vector2.Distance(transform.position, _positionable.Position);

            if(distance < Offset)
            {
                return;
            }

            Vector2 direction = (Vector3)_positionable.Position - transform.position;
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
