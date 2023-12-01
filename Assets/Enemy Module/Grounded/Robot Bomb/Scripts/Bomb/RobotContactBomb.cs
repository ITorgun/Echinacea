using System;
using UnityEngine;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public class RobotContactBomb : RobotBomb
    {
        public void Init(float damage)
        {
            Damage = damage;
        }

        public override void DealDamage(IDamageable damageable)
        {
            damageable.GetDamaged(Damage);
            Bombed?.Invoke(Damage);
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out RobotBombEnemy enemy))
            {
                return;
            }

            if (collision.TryGetComponent(out IDamageable damageable))
            {
                DealDamage(damageable);
            }
        }

        public override event Action<float> Bombed;
    }
}