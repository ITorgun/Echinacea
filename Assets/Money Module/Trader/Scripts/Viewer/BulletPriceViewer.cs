using Assets.WeaponModule.GunModule.Gun;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BulletPriceViewer : MonoBehaviour
{
    [SerializeField] private int _price = 50;
    [SerializeField] private Button _button;
    [SerializeField] private BulletConfig _config;

    public int Price { get => _price; set => _price = value; }

    public event Func<int, BulletConfig, bool> BoughtButtonPressed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnBought);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnBought);
    }

    private void OnBought()
    {
        if (BoughtButtonPressed?.Invoke(Price, _config) == true)
        {
            gameObject.SetActive(false);
        }
    }
}
