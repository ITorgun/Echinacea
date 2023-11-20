using Assets.Playable_Entity_Module;
using Assets.Player_Module.Scripts;
using System;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class Player : MonoBehaviour, IHealable, IHealthTaker, IDamageable, IWallet,
        ICollectorValueable, IMovable
    {
        [SerializeField] private float _health;
        [SerializeField] private int _level;

        public IRangeAttackDealer RangeAttackDealer { get; set; }

        private IPlayerMover _mover;

        public float Health { get => _health; private set => _health = value; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }
        public int Coins { get; private set; }
        public int Wallet { get; private set; }

        public float Speed => 15;

        public Transform Transform => transform;

        [Inject]
        public IPlayerMover Mover 
        { 
            get => _mover; 
            set => _mover = value; 
        }

        //public event Action<float> HealthChanged;
        //public event Action Died;
        //public event Action<int> LevelChanged;

        private void Start()
        {
            MaxHealth = 100;
            MinHealth = 0;
            Health = 20;

            //HealthChanged?.Invoke(Health);
            //LevelChanged?.Invoke(_level);

            Mover.StartMove();
        }

        private void Update()
        {
            Mover.Moving(transform);
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

        public void IncreaseLevel()
        {
            _level++;
            //LevelChanged.Invoke(_level);
        }

        public void ResetStats()
        {
            Health = 80;
            //HealthChanged.Invoke(Health);

            _level = 1;
            //LevelChanged.Invoke(_level);
        }

        public void AddCoins(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            Coins += value;
        }

        public void Add(int value)
        {
            Wallet += value;
            Debug.Log("Value: " + Wallet);
        }
    }
}