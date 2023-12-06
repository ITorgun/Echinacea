using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class DefaultGun : MonoBehaviour, IShootable
    {
        [SerializeField] private Image _view;

        private Coroutine _delaying;
        private float _damage;

        public Image Image => _view;
        public IMagazine Magazine { get; private set; }


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