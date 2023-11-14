using System;
using UnityEngine;

public interface IMovementEvents
{
    public event Action<Vector2> MovementDirectionUpdated;
}
