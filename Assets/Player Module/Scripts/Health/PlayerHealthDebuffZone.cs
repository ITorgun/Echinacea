using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDebuffZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamaged(5);
        }
    }
}
