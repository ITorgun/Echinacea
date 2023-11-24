using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagazine : IImageViewable
{
    IAmmo PullAmmo();
    void LoadAmmo(int ammoType);
}
