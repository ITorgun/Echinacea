using Assets.PlayableEntityModule.Mover;
using Assets.Player_Module.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDefabbZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPlayerMovable movable))
        {
            movable.PlayerMover.DebaffSpeed(9);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPlayerMovable movable))
        {
            movable.PlayerMover.ResetSpeed();
        }
    }
}
