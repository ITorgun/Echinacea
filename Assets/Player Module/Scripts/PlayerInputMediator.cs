using Assets.PlayerModule;
using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputMediator : IDisposable
{
    private PlayerMovement _movement;
    private ShotPosition _shotPosition;
    private PlayerModel _animatorConroller;

    public PlayerInputMediator(PlayerMovement movement, ShotPosition shotPosition, PlayerModel animatorConroller)
    {
        _movement = movement;
        _shotPosition = shotPosition;
        _animatorConroller = animatorConroller;

        _movement.InputDirectionUpdated += OnInputDirectionUpdated;
        _movement.MovementDirectionUpdated += OnMovementDirectionUpdated;
    }

    public void OnInputDirectionUpdated(Vector2 direction)
    {
        _shotPosition.UpdateState(direction);
    }

    public void OnMovementDirectionUpdated(Vector2 direction)
    {
        _animatorConroller.ChageAnimation(direction);
    }

    public void Dispose()
    {
        _movement.InputDirectionUpdated -= OnInputDirectionUpdated;
    }
}
