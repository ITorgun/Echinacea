using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILockShootPositionEvent
{
    public event Action ShootPositionLocked;
}
