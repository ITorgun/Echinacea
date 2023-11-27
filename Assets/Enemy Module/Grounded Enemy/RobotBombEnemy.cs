using Assets.Playable_Entity_Module.Mover;
using UnityEngine;
using Zenject;

namespace Assets.Enemy_Module.Grounded_Enemy
{
    public class RobotBombEnemy : MonoBehaviour, IHealthTaker, IDamageable
    {
        public IMovement RobotMovement { get; private set; }

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }


        [Inject]
        public void Constrcutor(IMovement robotMovement)
        {
            RobotMovement = robotMovement;
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
