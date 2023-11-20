using Assets.Playable_Entity_Module;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Enemy_Module.Grounded_Enemy
{
    public abstract class RobotBomb : MonoBehaviour, IDamageDealer
    {
        [field : SerializeField] public float Damage { get; protected set; }

        public abstract void DealDamage(IDamageable damageable);

        protected abstract void OnTriggerEnter2D(Collider2D collision);

        public abstract event Action<float> Bombed;
    }
}