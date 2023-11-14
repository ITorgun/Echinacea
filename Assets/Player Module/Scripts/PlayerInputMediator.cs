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

    public PlayerInputMediator(PlayerMovement movement, ShotPosition shotPosition)
    {
        _movement = movement;
        _shotPosition = shotPosition;

        _movement.DirectionUpdated += OnMovementDirectionUpdated;
    }

    public void OnMovementDirectionUpdated(Vector2 direction)
    {
        _shotPosition.UpdateState(direction);
    }

    public void Dispose()
    {
        _movement.DirectionUpdated -= OnMovementDirectionUpdated;
    }
}
