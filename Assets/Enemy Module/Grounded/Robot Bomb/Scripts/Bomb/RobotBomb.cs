using System;
using UnityEngine;
using Assets.PlayableEntityModule;

namespace Assets.EnemyModule.Grounded.RobotBomb
{
    public abstract class RobotBomb : MonoBehaviour, IDamageDealer
    {
        [field : SerializeField] public float Damage { get; protected set; }

        public abstract void DealDamage(IDamageable damageable);

        protected abstract void OnTriggerEnter2D(Collider2D collision);

        public abstract event Action<float> Bombed;
    }
}