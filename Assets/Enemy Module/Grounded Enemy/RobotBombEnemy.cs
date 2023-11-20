using Assets.Enemy_Module.Interfaces;
using Assets.Playable_Entity_Module;
using Assets.Playable_Entity_Module.IMover;
using UnityEngine;

namespace Assets.Enemy_Module.Grounded_Enemy
{
    public class RobotBombEnemy : MonoBehaviour, IHealthTaker, IDamageable, IMovable
    {
        private IFinder _finder;
        private IPositionable _positionable;
        private IMover _mover;

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        public Transform Transform => transform;

        private void Start()
        {
            Speed = 5;
        }

        public void InjectTarget(IPositionable positionable)
        {
            _positionable = positionable;
        }

        public void InjectFinder(IFinder finder)
        {
            _finder?.StopFind();
            _finder = finder;
            _finder.StartFind();
        }

        public void InjectMover(IMover mover)
        {
            _mover?.StopMove();
            _mover = mover;
            _mover.StartMove();
        }

        private void Update()
        {
            if (_finder.TryFindPosition(out Vector2 playerPosition))
            {
                _positionable.Position = playerPosition;
            }

            _mover.Moving(Time.deltaTime);
        }

        public bool IsHealthLessMin()
        {
            return Health <= MinHealth;
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public void GetDamaged(float damage)
        {
            Health -= damage;

            if (IsHealthLessMin())
            {
                Die();
            }
        }

        public void OnBombed(float damage)
        {
            GetDamaged(damage);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(transform.position, 5);
        }
    }
}
