using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmo
{
    float Speed { get; }
    float Damage { get; }
    float LifeTime { get; }

    void IncreaseInitialStats(float damage);
}
