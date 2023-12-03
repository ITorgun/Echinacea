using Assets.Player_Module.Scripts.Health;
using Assets.Player_Module.Scripts.Inventory;
using Assets.Player_Module.Scripts.Movement;
using System;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class Player : MonoBehaviour, IWallet,
        ICollectorValueable
    {
        public IPlayerMovement Movement { get; private set; }
        public IPlayerHealthTaker Health { get; private set; }
        public IPlayerInventory Inventory { get; private set; }

        public int Coins { get; private set; }
        public int Wallet { get; set; }

        [Inject]
        public void Constructor(IPlayerMovement playerMovement, IPlayerHealthTaker playerHealth,
            IPlayerInventory inventory)
        {
            Movement = playerMovement;
            Health = playerHealth;
            Inventory = inventory;

            Wallet = 100;
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