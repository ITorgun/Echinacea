using UnityEngine;

namespace Assets.Playable_Entity_Module.IMover
{
    public class MoverToPosition : IMover
    {
        private IMovable _movable;
        private IPositionable _positionable;
        private bool _isMoving;
        private Vector2 _previousPosition;

        public MoverToPosition(IMovable movable, IPositionable positionable)
        {
            _movable = movable;
            _positionable = positionable;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Moving(float deltaTime)
        {
            if (_isMoving == false || Vector3.Distance(_movable.Transform.position, _positionable.Position) < 0.2f)
            {
                _positionable.IsPositionSet = false;
                return;
            }

            Vector2 direction = (Vector3)_positionable.Position - _movable.Transform.position;
            _movable.Transform.Translate(_movable.Speed * deltaTime * direction.normalized);
        }
    }
}
