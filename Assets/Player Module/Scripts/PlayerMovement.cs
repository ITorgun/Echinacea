using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private Animator _animator;

        private IMovementEvents _movementEvents;
        private Vector2 _inputDirection;
        private Vector3 _currentDirection;
        private Transform _playerTransform;

        public IMovementEvents MovementEvents => _movementEvents;

        [Inject]
        private void Construct(IMovementEvents movementEvents)
        {
            _movementEvents = movementEvents;
            _movementEvents.Horizontal += OnHorisontalDirectionMoved;
            _movementEvents.Vertical += OnVerticalDirectionMoved;
        }

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void OnDisable()
        {
            _movementEvents.Horizontal -= OnHorisontalDirectionMoved;
            _movementEvents.Vertical -= OnVerticalDirectionMoved;
        }

        private void Update()
        {
            Move();
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

        private bool IsObstacleInDirection()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(_playerTransform.position, _inputDirection, 0.2f);

            foreach (var hitted in hits)
            {
                if (hitted.collider.TryGetComponent(out IObstacle obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        private void Move()
        {
            if (IsObstacleInDirection())
            {
                _currentDirection = Vector2.zero;
                Debug.DrawRay(_playerTransform.position, _currentDirection * 10, Color.white);
            }
            else
            {
                _currentDirection = _inputDirection;
            }
            _playerTransform.position += _moveSpeed * Time.deltaTime * _currentDirection;
        }

        public event Action<Vector2> InputDirectionUpdated;
        public event Action<Vector2> MovementDirectionUpdated;
    }
}