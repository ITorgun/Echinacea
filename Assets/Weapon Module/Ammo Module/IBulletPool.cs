using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weapon_Module.Ammo_Module
{
    public interface IBulletPool
    {
        public void InjectBulletType(BulletType bulletType);
    }
}
