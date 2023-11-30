using Assets.PlayerModule;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Enemy_Module.Grounded_Enemy
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
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                DealDamage(damageable);
            }
        }

        public override event Action<float> Bombed;
    }
}