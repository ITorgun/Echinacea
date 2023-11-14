using System;

namespace Assets.WeaponModule.GunModule.Gun
{
    public class PlayerShooter : IShooter, IDisposable, ISwitcherShootable, IAmmoLoader
    {
        private IAttackEvents _attackEvents;
        private IShootable _shootable;

        public PlayerShooter(IAttackEvents attackEvents, IShootable shootable)
        {
            _attackEvents = attackEvents;
            _shootable = shootable;

            _attackEvents.AttackPressed += OnAttackPressed;
        }

        public void SetShootable(IShootable shootable)
        {
            _shootable = shootable;
        }

        public void Shoot()
        {
            _shootable.Shoot();
        }

        public void Dispose()
        {
            _attackEvents.AttackPressed -= OnAttackPressed;
        }

        private void OnAttackPressed()
        {
            Shoot();
        }

        public void LoadAmmo(int ammoEnumValue)
        {
            _shootable.Magazine.LoadAmmo(ammoEnumValue);
        }
    }
}