using Assets.Money_Module.Trader;
using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class DefaultTraderMediator : MonoBehaviour
{
    private TraderPanel _panel;

    private IDefaultTrader _trader;

    [Inject]
    public void Constructor(IDefaultTrader trader, TraderPanel panel)
    {
        _trader = trader;
        _panel = panel;
    }

    private void OnEnable()
    {
        OnPlayerEntered();
        OnPlayerExited();
        TryBuyBullet();
    }

    private void OnDisable()
    {
        _trader.TradingStarted -= _panel.Show;
        _trader.TradingEnded -= _panel.Hide;
    }

    private void OnPlayerEntered()
    {
        _trader.TradingStarted += _panel.Show;
    }

    private void OnPlayerExited()
    {
        _trader.TradingEnded += _panel.Hide;
    }

    private bool OnBulletBought(int price, BulletConfig bulletConfig)
    {
        return _trader.TryBuyBullet(price, bulletConfig);
    }

    private void TryBuyBullet()
    {
        _panel.GoodsViewer.BulletViewer.BulletBought += OnBulletBought;
    }
}
