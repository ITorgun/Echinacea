using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;

        private IMovementEvents _movementEvents;
        private Vector2 _direction;
        private Vector3 _currentDirection;
        private Transform _playerTransform;

        public IMovementEvents MovementEvents => _movementEvents;

        [Inject]
        private void Construct(IMovementEvents movementEvents)
        {
            _movementEvents = movementEvents;
            _movementEvents.MovementDirectionUpdated += OnDirectionUpdated;
        }

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void OnDisable()
        {
            _movementEvents.MovementDirectionUpdated -= OnDirectionUpdated;
        }

        private void Update()
        {
            Move();
        }

        private void OnDirectionUpdated(Vector2 direction)
        {
            if (IsDirectionZero(direction))
            {
                _direction = Vector2.zero;
                return;
            }

            _direction = direction;
        }

        private bool IsDirectionZero(Vector2 direction)
        {
            return direction == Vector2.zero;
        }

        private bool IsObstacleInDirection()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(_playerTransform.position, _direction, 0.2f);

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
                _currentDirection = new Vector2(_direction.x, _direction.y);
            }
            _playerTransform.position += _moveSpeed * Time.deltaTime * _currentDirection;
        }
    }
}