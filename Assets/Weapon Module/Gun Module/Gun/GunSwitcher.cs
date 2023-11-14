using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class GunSwitcher : IDisposable
    {
        private ISwitchGunEvent _switchGunEvent;
        private List<IShootable> _shootables;
        private ISwitcherShootable _shooter;
        private int _currentShootableIndex = 0;

        public GunSwitcher(ISwitchGunEvent switchGunEvent, IEnumerable shootables, 
            ISwitcherShootable shooter)
        {
            _switchGunEvent = switchGunEvent;
            _shootables = (List<IShootable>)shootables;
            _shooter = shooter;

            _switchGunEvent.GunSwitched += OnGunSwitched;
        }

        public void Dispose()
        {
            _switchGunEvent.GunSwitched -= OnGunSwitched;
        }

        private void OnGunSwitched()
        {
            CountIndex();
            SetNextShootable();
        }

        private void CountIndex()
        {
            if (_currentShootableIndex == _shootables.Count - 1)
            {
                _currentShootableIndex = 0;
            }
            else
            {
                _currentShootableIndex++;
            }
        }

        private void SetNextShootable()
        {
            _shooter.InjectShootable(_shootables[_currentShootableIndex]);
        }
    }
}
