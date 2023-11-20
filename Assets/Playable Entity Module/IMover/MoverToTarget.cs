using TMPro;
using UnityEngine;

namespace Assets.Playable_Entity_Module.IMover
{
    class MoverToTarget : IMover
    {
        private ITargetable _targetable;
        private IMovable _movable;

        private bool _isMoving;

        public MoverToTarget(IMovable movable, ITargetable targetable)
        {
            _movable = movable;
            _targetable = targetable;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Moving(float deltaTime)
        {
            if (_isMoving == false)
            {
                // idle animation
                return;
            }

            if (Vector3.Distance(_movable.Transform.position, _targetable.TargetTransform.position) < 0.2f)
            {
                return;
            }

            Vector3 direction = _targetable.TargetTransform.position - _movable.Transform.position;
            _movable.Transform.Translate(_movable.Speed * deltaTime * direction.normalized);
        }
    }
}
