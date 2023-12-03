using Assets.Money_Module.Trader;
using Assets.Player_Module.Scripts.Inventory;
using Assets.PlayerModule;
using Assets.WeaponModule.GunModule.Gun;
using System;
using UnityEngine;

public class DefaultFirstLevelTrader : MonoBehaviour, IDefaultTrader
{
    private IPlayerInventory _inventory;
    private Player _player;

    public event Action TradingStarted;
    public event Action TradingEnded;

    public bool TryBuyBullet(int price, BulletConfig config)
    {
        if (_inventory == null)
            throw new Exception("Player's inventory is null");

        if (price > _player.Wallet)
        {
            Debug.LogError("�� ������� �����");
            return false;
        }

        _player.Wallet -= price;

        Debug.Log("�����: " + _player.Wallet);

        _inventory.BulletInventory.TryAddBulletType(config);
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _inventory = player.Inventory;
            _player = player;
            TradingStarted?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeSelf && collision.TryGetComponent(out Player player))
        {
            _inventory = null;
            TradingEnded?.Invoke();
        }
    }
}
