using System;

public class AmmoSwitcher : IDisposable
{
    private AmmoInventory _ammoInventory;
    private IAmmoLoader _ammoLoader;
    private IMagazine _magazine;
    private ISwitchAmmoEvent _switchAmmoEvent;
    private int _index = 0;

    public AmmoSwitcher(ISwitchAmmoEvent switchAmmoEvent, IMagazine magazine, 
        IAmmoLoader ammoLoader, AmmoInventory ammoInventory)
    {
        _ammoLoader = ammoLoader;
        _magazine = magazine;
        _switchAmmoEvent = switchAmmoEvent;
        _ammoInventory = ammoInventory;

        switchAmmoEvent.AmmoSwitched += OnAmmoSwitched;
    }

    public void Dispose()
    {
        _switchAmmoEvent.AmmoSwitched -= OnAmmoSwitched;
    }

    private void OnAmmoSwitched()
    {
        _index = (_index + 1) % _ammoInventory.GetAvaibleTypeCount(_magazine);
        int index = _ammoInventory.GetAvaibleBullet(_index, _magazine);
        SetNextAmmoType(index);
    }

    private void SetNextAmmoType(int index)
    {
        _ammoLoader.LoadAmmo(index);
    }
}
