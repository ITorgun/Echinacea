using Assets.Weapon_Module.Gun_Module.Bullet_Module.Default_Bullet.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public abstract class AmmoSubtypePool : MonoBehaviour, IAmmoPool
    {
        protected int MaxSize;
        protected List<IAmmo> GettedAmmoList;
        protected List<IAmmo> ReleasedAmmoList;

        public int CountAll { get; private set; }
        public int CountActive => CountAll - CountInactive;
        public int CountInactive => GettedAmmoList.Count;

        public virtual IAmmo Get()
        {
            IAmmo val;
            if (GettedAmmoList.Count == 0)
            {
                val = Create();
                CountAll++;
            }
            else
            {
                int index = GettedAmmoList.Count - 1;
                val = GettedAmmoList[index];
                GettedAmmoList.RemoveAt(index);
            }

            InitAmmo(val);
            ReleasedAmmoList.Add(val);

            return val;
        }

        public virtual void ClearPool()
        {
            foreach (IAmmo item in GettedAmmoList)
            {
                Destroy(item);
            }

            foreach (IAmmo item in ReleasedAmmoList)
            {
                item.Collided -= OnAmmoCollided;
                item.Collided += OnReleasedAmmoCollided;
            }

            GettedAmmoList.Clear();
            ReleasedAmmoList.Clear();
            CountAll = 0;
        }

        public virtual void Release(IAmmo element)
        {
            if (GettedAmmoList.Count > 0)
            {
                for (int i = 0; i < GettedAmmoList.Count; i++)
                {
                    if (element == GettedAmmoList[i])
                    {
                        throw new InvalidOperationException("Trying to release an object that has already been released to the pool.");
                    }
                }
            }

            OnRelease(element);
            if (CountInactive < MaxSize)
            {
                GettedAmmoList.Add(element);
            }
            else
            {
                Destroy(element);
            }
        }

        public virtual void OnAmmoCollided(IAmmo ammo)
        {
            Release(ammo);
        }

        protected virtual void OnReleasedAmmoCollided(IAmmo ammo)
        {
            ammo.Collided -= OnReleasedAmmoCollided;
            Destroy(ammo);
        }

        protected virtual void Destroy(IAmmo ammo)
        {
            ammo.Destroy();
        }

        public abstract IAmmo Create();
        public abstract void InitAmmo(IAmmo ammo);
        public abstract void OnRelease(IAmmo ammo);
    }
}