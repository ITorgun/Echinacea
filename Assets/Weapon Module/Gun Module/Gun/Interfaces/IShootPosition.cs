using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootPosition
{
    public Transform CurrentPosition { get; }
    public Vector2 CurrentVector { get;  }
}
