using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthTaker, IHealable, IDamageable
{
    [SerializeField] private float _health;

    public float Health { get => _health; private set => _health = value; }
    public float MaxHealth { get; private set; }
    public float MinHealth { get; private set; }

    private void Start()
    {
        MaxHealth = 100;
        MinHealth = 0;
        Health = 20;
    }

    public bool IsHealthLessMin()
    {
        return Health <= MinHealth;
    }

    public void Die()
    {
        Debug.Log("Игрок умер!");

        Health = MaxHealth;

        //Died.Invoke();
    }

    public void GetDamaged(float damage)
    {
        Health -= damage;
        //HealthChanged?.Invoke(Health);

        if (IsHealthLessMin())
        {
            Die();
        }
    }

    public void Heal(float healValue)
    {
        if (Health >= MaxHealth)
        {
            Debug.Log("Максимум хп");
            return;
        }

        Health += healValue;

        //HealthChanged?.Invoke(Health);
    }
}
