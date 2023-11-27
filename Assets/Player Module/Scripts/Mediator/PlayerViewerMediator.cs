using System;
using Assets.Player_Module.Scripts.Health;
using Assets.Player_Module.UI;
using Assets.WeaponModule.GunModule.Gun;

public class PlayerViewerMediator : IDisposable
{
    private IPlayerHealthTaker _health;
    private IHealthViewer _healthViewer;

    private PlayerInventory _inventory;
    private WeaponImageViewer _weaponImageViewer;

    public PlayerViewerMediator(IPlayerHealthTaker playerHealth, IHealthViewer floatViewer, 
        PlayerInventory inventory, WeaponImageViewer weaponImageViewer)
    {
        _health = playerHealth;
        _healthViewer = floatViewer;
        _health.HealthChanged += OnPlayerHealthChanged;

        _inventory = inventory;
        _weaponImageViewer = weaponImageViewer;
        _inventory.GunInventory.ShootableSwitcted += OnShootableSwiched;

        _inventory.AmmoSwitcher.AmmoSwithted += OnAmmoTypeSwitched;
    }

    public void Dispose()
    {
        _health.HealthChanged += OnPlayerHealthChanged;
    }

    public void InitViewers()
    {
        _healthViewer.SetInitialHealthValue(_health.Health);
    }

    private void OnPlayerHealthChanged(float healthValue)
    {
        _healthViewer.OnHealthChanged(healthValue);
    }

    private void OnShootableSwiched(IShootable shootable)
    {
        _weaponImageViewer.OnShootableSwitched(shootable, shootable.Magazine);
    }

    private void OnAmmoTypeSwitched(IImageViewable imageViewable)
    {
        _weaponImageViewer.MagazineViewer.SetImage(imageViewable);
    }
}
