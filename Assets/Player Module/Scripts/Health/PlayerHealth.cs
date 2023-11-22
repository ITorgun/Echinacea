using Assets.Player_Module.Scripts.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealthTaker, IHealable, IDamageable
{
    [SerializeField] private float _health;

    public float Health { get => _health; private set => _health = value; }
    public float MaxHealth { get; private set; }
    public float MinHealth { get; private set; }

    public event Action<float> HealthChanged;

    private void Start()
    {
        MaxHealth = 100;
        MinHealth = 0;
        Health = 90;
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
        HealthChanged?.Invoke(Health);

        Debug.Log("Получил урон. Осталось хп: " + Health);

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

        HealthChanged?.Invoke(Health);
    }
}
