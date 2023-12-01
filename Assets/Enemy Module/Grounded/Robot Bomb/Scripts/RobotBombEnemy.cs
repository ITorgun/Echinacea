using UnityEngine;
using Assets.PlayableEntityModule.Mover;
using Assets.Player_Module.Scripts;
using System;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotBombEnemy : MonoBehaviour, IHealthTaker, IDamageable, IDieEvent<RobotBombEnemy>
    {
        [SerializeField] private RobotBomb _bomb;

        public IMovement RobotMovement { get; private set; }

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }

        public event Action<RobotBombEnemy> Died;

        private void Awake()
        {
            RobotMovement = GetComponent<IMovement>();
        }

        private void OnEnable()
        {
            _bomb.Bombed += OnBombed;
        }

        private void OnDisable()
        {
            _bomb.Bombed -= null;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public bool IsHealthLessMin()
        {
            return Health <= MinHealth;
        }

        public void Die()
        {
            gameObject.SetActive(false);
            Died?.Invoke(this);
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
