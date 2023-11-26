using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Weapon_Module.Ammo_Module.Interfaces
{
    public interface IDefaultBulletFactory
    {
        public DefaultBullet GetDefaultBullet(DefaultBulletType type, Transform bulletTranform, Transform parent);
    }
}
