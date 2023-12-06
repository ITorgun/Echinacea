using Assets.Player_Module.Scripts.Health;
using Assets.Player_Module.Scripts.Inventory;
using Assets.Player_Module.Scripts.Movement;
using System;
using UnityEngine;
using Zenject;

namespace Assets.PlayerModule
{
    public class Player : MonoBehaviour, ICollectorValueable
    {
        public IPlayerMovement Movement { get; private set; }
        public IPlayerHealthTaker Health { get; private set; }
        public IPlayerInventory Inventory { get; private set; }
        public IWallet Wallet { get; private set; }

        public int Coins { get; private set; }

        [Inject]
        public void Constructor(IPlayerMovement movement, IPlayerHealthTaker health,
            IPlayerInventory inventory, IWallet wallet)
        {
            Movement = movement;
            Health = health;
            Inventory = inventory;
            Wallet = wallet;
        }

        public void AddCoins(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            Coins += value;
            Wallet.Add(Coins);
        }
    }
}