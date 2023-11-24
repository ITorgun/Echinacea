using Assets.WeaponModule.GunModule.Gun;
using System;
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
        private int _index = 0;
        private AmmoSwitcher _ammoSwitcher;

        public event Action<IShootable> ShootableSwitcted;

        [Inject]
        public void Constructor(ISwitchGunEvent switchGunEvent,
            ISwitcherShootable shooter, AmmoSwitcher ammoSwitcher)
        {
            _switchGunEvent = switchGunEvent;
            _switcherShootable = shooter;
            _switchGunEvent.GunSwitched += OnGunSwitched;

            _ammoSwitcher = ammoSwitcher;
        }

        private void Start()
        {
            IShootable[] shootables = GetComponentsInChildren<IShootable>();
            _shootables = new List<IShootable>(shootables);

            for (int i = 1; i < shootables.Length; i++)
            {
                _shootables[i].Hide();
            }

            ShootableSwitcted?.Invoke(_shootables[_index]);
            _switcherShootable.InjectShootable(_shootables[_index]);
            _ammoSwitcher.SetMagazine(_shootables[_index].Magazine);
        }

        public void Dispose()
        {
            _switchGunEvent.GunSwitched -= OnGunSwitched;
        }

        private void OnGunSwitched()
        {
            SwitchShootable();
            ShootableSwitcted?.Invoke(_shootables[_index]);
            InjectShootable();
        }

        private void SwitchShootable()
        {
            _shootables[_index].Hide();
            _index = (_index + 1) % _shootables.Count;
            _shootables[_index].Show();
        }

        private void InjectShootable()
        {
            _switcherShootable.InjectShootable(_shootables[_index]);
            _ammoSwitcher.SetMagazine(_shootables[_index].Magazine);
        }
    }
}
