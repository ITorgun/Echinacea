using UnityEngine.UI;

namespace Assets.Weapon_Module.Interfaces
{
    public interface IDefaultMagazine : IMagazine
    {
        public DefaultBulletType BulletType { get; }

        public void InjectBulletType(DefaultBulletType bulletType);
        public void SwitchImage(DefaultBulletType bulletType);
    }
}
