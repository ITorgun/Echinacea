using Assets.Playable_Entity_Module;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Player_Module.Scripts
{
    public class DefaultPlayerMover : IPlayerMover, IDisposable
    {
        [SerializeField] private Animator _animator;

        private IMovementEvents _movementEvents;
        private Vector2 _inputDirection;
        private Vector3 _currentDirection;
        private bool _isMoving;

        public float Speed { get; private set; }
        public float CurrentSpeed { get; set; }

        public IMovementEvents MovementEvents => _movementEvents;

        public event Action<Vector2> InputDirectionUpdated;
        public event Action<Vector2> MovementDirectionUpdated;

        public DefaultPlayerMover(IMovementEvents movementEvents)
        {
            _movementEvents = movementEvents;
            _movementEvents.Horizontal += OnHorisontalDirectionMoved;
            _movementEvents.Vertical += OnVerticalDirectionMoved;
        }

        public void Init(float speed)
        {
            Speed = speed;
        }

        public void Dispose()
        {
            _movementEvents.Horizontal -= OnHorisontalDirectionMoved;
            _movementEvents.Vertical -= OnVerticalDirectionMoved;
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Moving(Transform transform)
        {
            if (_isMoving == false)
            {
                Debug.Log("Player moving is false");
                return;
            }

            Move(transform, Speed);
        }

        public void DebaffSpeed(float speed)
        {
            CurrentSpeed -= speed;
        }

        public void ResetSpeed()
        {
            CurrentSpeed = Speed;
        }

        private bool IsAxisZero(float axis)
        {
            return axis == 0;
        }

        private void OnHorisontalDirectionMoved(float direction)
        {
            if (IsAxisZero(direction))
            {
                _inputDirection = new Vector2(0, 0);
                MovementDirectionUpdated?.Invoke(_inputDirection);
                return;
            }

            _inputDirection = new Vector2(direction, 0);
            InputDirectionUpdated?.Invoke(_inputDirection);
            MovementDirectionUpdated?.Invoke(_inputDirection);
        }

        private void OnVerticalDirectionMoved(float direction)
        {
            if (IsAxisZero(direction))
            {
                _inputDirection = new Vector2(0, 0);
                MovementDirectionUpdated(_inputDirection);
                return;
            }

            _inputDirection = new Vector2(0, direction);
            InputDirectionUpdated?.Invoke(_inputDirection);
            MovementDirectionUpdated?.Invoke(_inputDirection);
        }

        private bool IsObstacleInDirection(Transform transform)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _inputDirection, 0.2f);

            foreach (var hitted in hits)
            {
                if (hitted.collider.TryGetComponent(out IObstacle obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        private void Move(Transform transform, float moveSpeed)
        {
            if (IsObstacleInDirection(transform))
            {
                _currentDirection = Vector2.zero;
                Debug.DrawRay(transform.position, _currentDirection * 10, Color.white);
            }
            else
            {
                _currentDirection = _inputDirection;
            }
            transform.position += moveSpeed * Time.deltaTime * _currentDirection;
        }
    }
}
