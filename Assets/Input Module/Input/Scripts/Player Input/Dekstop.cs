using System;
using UnityEngine.InputSystem;

namespace Assets.InputModule
{
    public class Dekstop : PlayerInput
    {
        public override event Action<float> Horizontal;
        public override event Action<float> Vertical;
        public override event Action RangeAttackPressed;
        public override event Action GunSwitched;
        public override event Action AmmoSwitched;
        public override event Action ShootPositionLocked;

        protected override void RaiseXMovementDirectionChanged(InputAction.CallbackContext movementContext)
        {
            if (movementContext.performed)
            {
                IsMovedOnX = true;
                Horizontal?.Invoke(movementContext.ReadValue<float>());
            }
            else if (movementContext.canceled)
            {
                IsMovedOnX = false;

                if (IsMovedOnY)
                {
                    Vertical?.Invoke(Actions.KeyboardMouse.YMovement.ReadValue<float>());
                }
                else
                {
                    Horizontal?.Invoke(0);
                }
            }
        }

        protected override void RaiseYMovementDirectionChanged(InputAction.CallbackContext movementContext)
        {
            if (movementContext.performed)
            {
                IsMovedOnY = true;
                Vertical?.Invoke(movementContext.ReadValue<float>());
            }
            else if (movementContext.canceled)
            {
                IsMovedOnY = false;

                if (IsMovedOnX)
                {
                    Horizontal?.Invoke(Actions.KeyboardMouse.XMovement.ReadValue<float>());
                }
                else
                {
                    Vertical?.Invoke(0);
                }
            }
        }

        protected override void RaiseAttackPressed(InputAction.CallbackContext attackContext)
        {
            if (attackContext.performed)
            {
                RangeAttackPressed?.Invoke();
            }
        }

        protected override void RaiseGunSwitched(InputAction.CallbackContext gunContext)
        {
            if (gunContext.performed)
            {
                GunSwitched?.Invoke();
            }
        }

        protected override void RaiseAmmoSwitched(InputAction.CallbackContext ammoContext)
        {
            if (ammoContext.performed)
            {
                AmmoSwitched?.Invoke();
            }
        }

        protected override void RaiseShootPositionLocked(InputAction.CallbackContext shootPositionContext)
        {
            if (shootPositionContext.performed)
            {
                ShootPositionLocked?.Invoke();
            }
        }
    }
}