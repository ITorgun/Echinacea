using Assets.Playable_Entity_Module;
using Assets.Player_Module.Scripts.Health;
using Assets.Player_Module.Scripts.Movement;
using System;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class Player : MonoBehaviour, IWallet,
        ICollectorValueable
    {
        [SerializeField] private int _level;

        public IPlayerMovement Movement { get; private set; }
        public IPlayerHealthTaker Health { get; private set; }

        public int Coins { get; private set; }
        public int Wallet { get; private set; }

        [Inject]
        public void Constructor(IPlayerMovement playerMovement, IPlayerHealthTaker playerHealth)
        {
            Movement = playerMovement;
            Health = playerHealth;
        }


        public void IncreaseLevel()
        {
            _level++;
            //LevelChanged.Invoke(_level);
        }

        public void ResetStats()
        {
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