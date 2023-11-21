using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class DefaultGun : MonoBehaviour, IShootable
    {
        private Coroutine _delaying;
        public IMagazine Magazine { get; private set; }

        private float _damage;

        [Inject]
        private void Construct(IMagazine magazine)
        {
            Magazine = magazine;
        }

        private void OnDisable()
        {
            if (_delaying != null)
            {
                StopCoroutine(_delaying);
            }
        }

        public void Shoot()
        {
            Debug.Log("Default Gun");

            IAmmo ammo = Magazine.PullAmmo();
            ammo.IncreaseInitialStats(_damage);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}