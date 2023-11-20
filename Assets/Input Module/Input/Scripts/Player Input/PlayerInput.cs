using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Zenject;

public abstract class PlayerInput : MonoBehaviour, IMovementEvents, IRangeAttackEvents, ISwitchGunEvent,
    ISwitchAmmoEvent
{
    protected InputActions Actions;

    //public abstract event Action<Vector2> MovementDirectionUpdated;

    public abstract event Action RangeAttackPressed;
    public abstract event Action GunSwitched;
    public abstract event Action AmmoSwitched;
    public abstract event Action<float> Horizontal;
    public abstract event Action<float> Vertical;

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
}