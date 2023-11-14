using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public abstract class AmmoPool : MonoBehaviour
    {
        protected List<IAmmo> _gettedAmmoList;
        protected List<IAmmo> _releasedAmmoList;
        private int _maxSize;

        public int CountAll { get; private set; }
        public int CountActive => CountAll - CountInactive;
        public int CountInactive => _gettedAmmoList.Count;

        [Inject]
        public void Construct(int defaultCapacity = 10, int maxSize = 50)
        {
            if (maxSize <= 0)
            {
                throw new ArgumentException("Max Size must be greater than 0", "maxSize");
            }

            _gettedAmmoList = new List<IAmmo>(defaultCapacity);
            _maxSize = maxSize;
            _releasedAmmoList = new List<IAmmo>();
        }

        public virtual IAmmo Get()
        {
            IAmmo val;
            if (_gettedAmmoList.Count == 0)
            {
                val = Create();
                CountAll++;
            }
            else
            {
                int index = _gettedAmmoList.Count - 1;
                val = _gettedAmmoList[index];
                _gettedAmmoList.RemoveAt(index);
            }

            InitAmmo(val);
            _releasedAmmoList.Add(val);

            return val;
        }

        public void Release(IAmmo element)
        {
            if (_gettedAmmoList.Count > 0)
            {
                for (int i = 0; i < _gettedAmmoList.Count; i++)
                {
                    if (element == _gettedAmmoList[i])
                    {
                        throw new InvalidOperationException("Trying to release an object that has already been released to the pool.");
                    }
                }
            }

            OnRelease(element);
            if (CountInactive < _maxSize)
            {
                _gettedAmmoList.Add(element);
            }
            else
            {
                Destroy(element);
            }
        }

        public void ClearPool()
        {
            foreach (IAmmo item in _gettedAmmoList)
            {
                Destroy(item);
            }

            foreach (IAmmo item in _releasedAmmoList)
            {
                item.Collided -= OnAmmoCollided;
                item.Collided += OnPreviousBulletTypeCollided;
            }

            _gettedAmmoList.Clear();
            _releasedAmmoList.Clear();
            CountAll = 0;
        }

        public void Dispose()
        {
            ClearPool();
        }

        protected virtual void OnPreviousBulletTypeCollided(IAmmo ammo)
        {
            ammo.Collided -= OnPreviousBulletTypeCollided;
            Destroy(ammo);
        }

        protected virtual void OnAmmoCollided(IAmmo ammo)
        {
            Release(ammo);
        }

        protected virtual void Destroy(IAmmo ammo)
        {
            ammo.Destroy();
        }

        protected abstract IAmmo Create();
        protected abstract void InitAmmo(IAmmo ammo);
        protected abstract void OnRelease(IAmmo ammo);
    }
}