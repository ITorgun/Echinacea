using System;

public class AmmoSwitcher : IDisposable
{
    private BulletInventory _ammoInventory;
    private IMagazine _magazine;
    private ISwitchAmmoEvent _switchAmmoEvent;
    private int _index = 0;

    public AmmoSwitcher(ISwitchAmmoEvent switchAmmoEvent, BulletInventory ammoInventory)
    {
        _switchAmmoEvent = switchAmmoEvent;
        _ammoInventory = ammoInventory;

        switchAmmoEvent.AmmoSwitched += OnAmmoSwitched;
    }

    public void SetMagazine(IMagazine magazine)
    {
        _magazine = magazine;
    }

    public void Dispose()
    {
        _switchAmmoEvent.AmmoSwitched -= OnAmmoSwitched;
    }

    private void OnAmmoSwitched()
    {
        _index = (_index + 1) % _ammoInventory.GetAvaibleBulletTypeCount(_magazine);
        _ammoInventory.InjectBulletType(_index, _magazine);
    }
}
