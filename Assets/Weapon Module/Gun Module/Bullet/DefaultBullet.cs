using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class DefaultBullet : MonoBehaviour, IBullet
    {
        private Coroutine _flying;

        public DefaultBulletType Type { get; private set; }
        public float Speed { get; private set; }
        public float Damage { get; private set; }
        public float LifeTime { get; private set; }

        public void Init(DefaultBulletConfig config)
        {
            Type = config.BulletType;
            Speed = config.Speed;
            Damage = config.Damage;
            LifeTime = config.LifeTime;
        }

        public void IncreaseInitialStats(float damage)
        {
            Damage += damage;
        }

        public void StartFlying()
        {
            _flying = StartCoroutine(Flying());
        }

        public void Collide()
        {
            if (_flying != null)
            {
                StopCoroutine(_flying);
            }

            Collided?.Invoke(this);
        }

        private IEnumerator Flying()
        {
            float currentLifeTime = 0;
            yield return new WaitWhile(() =>
            {
                Vector2 newPosition = transform.position + transform.right * (Time.deltaTime * Speed);
                transform.position = newPosition;
                currentLifeTime += Time.deltaTime;
                return currentLifeTime <= LifeTime;
            });
            Collide();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IObstacle obstacle))
            {
                Collide();
            }
            else if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.SetDamage(Damage);
                Collide();
            }
        }

        void IBullet.Destroy()
        {
            Destroy(gameObject);
        }

        public event Action<IBullet> Collided;
    }
}