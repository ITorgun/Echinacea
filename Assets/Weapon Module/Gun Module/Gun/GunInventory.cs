using Assets.WeaponModule.GunModule.Gun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Weapon_Module.Gun_Module.Gun
{
    public class GunInventory : MonoBehaviour
    {
        private ISwitchGunEvent _switchGunEvent;
        private List<IShootable> _shootables;
        private ISwitcherShootable _switcherShootable;
        private int _currentShootableIndex = 0;

        [Inject]
        public void Constructor(ISwitchGunEvent switchGunEvent,
            ISwitcherShootable shooter)
        {
            _switchGunEvent = switchGunEvent;
            _switcherShootable = shooter;
            _switchGunEvent.GunSwitched += OnGunSwitched;
        }

        private void Start()
        {
            IShootable[] shootables = GetComponentsInChildren<IShootable>();
            _shootables = new List<IShootable>(shootables);
            _switcherShootable.InjectShootable(_shootables[0]);
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
                _shootables[_currentShootableIndex].Hide();
                _currentShootableIndex++;
                _shootables[_currentShootableIndex].Show();
            }
        }

        private void SetNextShootable()
        {
            _switcherShootable.InjectShootable(_shootables[_currentShootableIndex]);
        }
    }
}
