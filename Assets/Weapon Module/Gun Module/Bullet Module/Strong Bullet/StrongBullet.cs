using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections;
using UnityEngine;

public class StrongBullet : MonoBehaviour, IBullet
{
    private Coroutine _flying;

    [field: SerializeField] public StrongBulletType Type { get; private set; }

    public float Speed { get; private set; }
    public float Damage { get; private set; }
    public float LifeTime { get; private set; }

    private float CurrentDamage;

    public void Init(StrongBulletConfig config)
    {
        Type = config.BulletType;
        Speed = config.Speed;
        Damage = config.Damage;
        LifeTime = config.LifeTime;

        CurrentDamage = Damage;
    }

    public void IncreaseInitialStats(float damage)
    {
        CurrentDamage = Damage + damage;
    }

    public void StartFlying(Vector2 direction)
    {
        _flying = StartCoroutine(Flying(direction));
    }

    public void Collide()
    {
        if (_flying != null)
        {
            StopCoroutine(_flying);
        }

        Collided?.Invoke(this);
    }

    public void Hide()
    {
        CurrentDamage = Damage;
        gameObject.SetActive(false);
    }

    void IAmmo.Destroy()
    {
        Destroy(gameObject);
    }

    private IEnumerator Flying(Vector2 direction)
    {
        float currentLifeTime = 0;
        yield return new WaitWhile(() =>
        {
            Vector2 newPosition = transform.position + (Vector3)direction * (Time.deltaTime * Speed);
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
            damageable.GetDamaged(CurrentDamage);
            Collide();
        }
    }

    public event Action<IAmmo> Collided;
}
