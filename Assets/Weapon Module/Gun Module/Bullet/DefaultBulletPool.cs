using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class DefaultBulletPool : MonoBehaviour
    {
        private DefaultBulletFactory _factory;
        private ShotPosition _shotTranform;
        private ObjectPool<DefaultBullet> _pool;
        private DefaultBulletType _currentType;

        [Inject]
        public void Construct(DefaultBulletType type, DefaultBulletFactory factory,
            ShotPosition shotPosition)
        {
            _currentType = type;
            _factory = factory;
            _shotTranform = shotPosition;
            _pool = new ObjectPool<DefaultBullet>(OnCreateBullet, OnGetFromPool, OnReleaseFromPool, DestroyPreviousBulletType);
        }

        public void InjectAmmoType(DefaultBulletType type)
        {
            _currentType = type;
            _pool.Clear();
        }

        public DefaultBullet Get()
        {
            return _pool.Get();
        }

        private DefaultBullet OnCreateBullet()
        {
            DefaultBullet bullet = _factory.Get(_currentType, _shotTranform.CurrentTransform, transform);
            bullet.Collided += OnBulletCollided;
            return bullet;
        }

        private void OnGetFromPool(DefaultBullet bullet)
        {
            bullet.transform.SetPositionAndRotation(_shotTranform.CurrentTransform.position, _shotTranform.transform.rotation);
            bullet.gameObject.SetActive(true);
            bullet.StartFlying();
        }

        private void DestroyPreviousBulletType(DefaultBullet bullet)
        {
            bullet.Collided -= OnBulletCollided;
            Destroy(bullet.gameObject);
        }

        private void OnReleaseFromPool(DefaultBullet bullet)
        {
            if (bullet.Type != _currentType)
            {
                DestroyPreviousBulletType(bullet);
                return;
            }

            bullet.gameObject.SetActive(false);
        }

        private void OnBulletCollided(IBullet bullet)
        {
            DefaultBullet defaultBullet = (DefaultBullet)bullet;
            _pool.Release(defaultBullet);
        }
    }
}