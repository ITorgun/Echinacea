using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dekstop : PlayerInput
{
    public override event Action<Vector2> MovementDirectionUpdated;
    public override event Action AttackPressed;
    public override event Action GunSwitched;
    public override event Action AmmoSwitched;

    protected override void RaiseMovementDirectionChanged(InputAction.CallbackContext movementContext)
    {
        if (movementContext.performed)
        {
            MovementDirectionUpdated?.Invoke(movementContext.action.ReadValue<Vector2>());
        }
        else if (movementContext.canceled)
        {
            MovementDirectionUpdated?.Invoke(Vector2.zero);
        }
    }

    protected override void RaiseAttackPressed(InputAction.CallbackContext attackContext)
    {
        if (attackContext.performed)
        {
            AttackPressed?.Invoke();
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
}
