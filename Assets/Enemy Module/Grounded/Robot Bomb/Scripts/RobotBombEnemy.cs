using UnityEngine;
using Assets.Playable_Entity_Module.Mover;

namespace Assets.Enemy_Module.Grounded.Robot_Bomb
{
    public class RobotBombEnemy : MonoBehaviour, IHealthTaker, IDamageable
    {
        [SerializeField] private RobotBomb _bomb;

        public IMovement RobotMovement { get; private set; }

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }


        private void Awake()
        {
            RobotMovement = GetComponent<IMovement>();
            _bomb.Bombed += OnBombed;
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
