using UnityEngine;

namespace Assets.WeaponModule.GunModule.Gun
{
    public abstract class BulletConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime;

        public float Speed => _speed;
        public float Damage => _damage;
        public float LifeTime => _lifeTime;
    }
}