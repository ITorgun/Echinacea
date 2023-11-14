using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthTaker
{
    public float Health { get; }
    public float MaxHealth { get; }
    public float MinHealth { get; }
}
