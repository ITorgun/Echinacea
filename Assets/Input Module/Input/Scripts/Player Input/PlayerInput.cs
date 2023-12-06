using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.InputModule
{
    public abstract class PlayerInput : MonoBehaviour, IMovementEvents, IRangeAttackEvents, ISwitchGunEvent,
    ISwitchAmmoEvent, ILockShootPositionEvent
    {
        protected InputActions Actions;

        public abstract event Action RangeAttackPressed;
        public abstract event Action GunSwitched;
        public abstract event Action AmmoSwitched;
        public abstract event Action<float> Horizontal;
        public abstract event Action<float> Vertical;
        public abstract event Action ShootPositionLocked;

        protected bool IsMovedOnY = false;
        protected bool IsMovedOnX = false;

        [Inject]
        private void Construct(InputActions actions)
        {
            Actions = actions;

            Actions.KeyboardMouse.XMovement.performed += moveDirectionContext =>
            RaiseXMovementDirectionChanged(moveDirectionContext);
            Actions.KeyboardMouse.XMovement.canceled += moveDirectionContext =>
            RaiseXMovementDirectionChanged(moveDirectionContext);

            Actions.KeyboardMouse.YMovement.performed += moveDirectionContext =>
            RaiseYMovementDirectionChanged(moveDirectionContext);
            Actions.KeyboardMouse.YMovement.canceled += moveDirectionContext =>
            RaiseYMovementDirectionChanged(moveDirectionContext);

            Actions.KeyboardMouse.Attack.performed += attackContext =>
            RaiseAttackPressed(attackContext);

            Actions.KeyboardMouse.SwitchGun.performed += swithGunContext =>
            RaiseGunSwitched(swithGunContext);

            Actions.KeyboardMouse.SwitchAmmoType.performed += swithAmmoContext =>
            RaiseAmmoSwitched(swithAmmoContext);

            Actions.KeyboardMouse.LockShootPosition.performed += shootPositionContext =>
            RaiseShootPositionLocked(shootPositionContext);
        }

        protected virtual void OnEnable()
        {
            Actions.Enable();
        }

        protected virtual void OnDisable()
        {
            Actions.Disable();
        }

        protected abstract void RaiseAttackPressed(InputAction.CallbackContext attackContext);
        protected abstract void RaiseXMovementDirectionChanged(InputAction.CallbackContext movementcontext);
        protected abstract void RaiseYMovementDirectionChanged(InputAction.CallbackContext movementcontext);
        protected abstract void RaiseGunSwitched(InputAction.CallbackContext gunContext);
        protected abstract void RaiseAmmoSwitched(InputAction.CallbackContext ammoContext);
        protected abstract void RaiseShootPositionLocked(InputAction.CallbackContext shootPositionContext);
    }
}