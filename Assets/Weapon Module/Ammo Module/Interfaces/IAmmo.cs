using Assets.WeaponModule.GunModule.Gun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmo
{
    float Speed { get; }
    float Damage { get; }
    float LifeTime { get; }

    void IncreaseInitialStats(float damage);
    void StartFlying(Vector2 direction);
    void Collide();
    void Hide();
    void Destroy();

    event Action<IAmmo> Collided;
}