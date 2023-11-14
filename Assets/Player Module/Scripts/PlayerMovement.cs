using System;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;

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

        private void OnHorisontalDirectionMoved(float direction)
        {
            if (direction == 0)
            {
                _inputDirection = new Vector2(0, 0);
                return;
            }

            _inputDirection = new Vector2(direction, 0);
            DirectionUpdated?.Invoke(_inputDirection);
        }

        private void OnVerticalDirectionMoved(float direction)
        {
            if (direction == 0)
            {
                _inputDirection = new Vector2(0, 0);
                return;
            }

            _inputDirection = new Vector2(0, direction);
            DirectionUpdated?.Invoke(_inputDirection);
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

        public event Action<Vector2> DirectionUpdated;
    }
}