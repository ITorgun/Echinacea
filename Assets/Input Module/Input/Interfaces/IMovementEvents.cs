using System;
using UnityEngine;
using UnityEngine.Animations;

public interface IMovementEvents
{
    public event Action<float> Horizontal;
    public event Action<float> Vertical;
}