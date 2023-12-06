using Assets.Playable_Entity_Module;
using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletsViewer : MonoBehaviour, IViewable
{
    private List<BulletPriceViewer> _priceViewers;

    public event Func<int, BulletConfig, bool> BulletBought;

    private void Awake()
    {
        _priceViewers = new List<BulletPriceViewer>();
        BulletPriceViewer[] viewers = GetComponentsInChildren<BulletPriceViewer>();
        _priceViewers.AddRange(viewers);
    }

    private void OnEnable()
    {
        _priceViewers.ForEach(view => view.BoughtButtonPressed += OnBulletBoughtButtonPressed);
    }

    private void OnDisable()
    {
        _priceViewers.ForEach(view => view.BoughtButtonPressed -= OnBulletBoughtButtonPressed);
    }

    private bool OnBulletBoughtButtonPressed(int price, BulletConfig bulletConfig)
    {
        if (BulletBought == null)
            throw new Exception("BulletBought event is null");

        return BulletBought.Invoke(price, bulletConfig);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
