using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public abstract class PlayerInput : MonoBehaviour, IMovementEvents, IAttackEvents, ISwitchGunEvent,
    ISwitchAmmoEvent
{
    protected InputActions Actions;

    public abstract event Action<Vector2> MovementDirectionUpdated;
    public abstract event Action AttackPressed;
    public abstract event Action GunSwitched;
    public abstract event Action AmmoSwitched;

    [Inject]
    private void Construct(InputActions actions)
    {
        Actions = actions;

        Actions.KeyboardMouse.Movement.performed += moveDirectionContext =>
        RaiseMovementDirectionChanged(moveDirectionContext);
        Actions.KeyboardMouse.Movement.canceled += moveDirectionContext =>
        RaiseMovementDirectionChanged(moveDirectionContext);

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
    protected abstract void RaiseMovementDirectionChanged(InputAction.CallbackContext movementcontext);
    protected abstract void RaiseGunSwitched(InputAction.CallbackContext gunContext);
    protected abstract void RaiseAmmoSwitched(InputAction.CallbackContext ammoContext);
}