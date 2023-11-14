using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string IdleAnimation = "Idle";
    private readonly string MovingDownAnimation = "MovingDown";
    private readonly string MovingUpAnimation = "MovingUp";
    private readonly string MovingHorisontalAnimation = "MovingHorisontal";

    public void ChageAnimation(Vector2 direction)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0));

        if (direction == Vector2.zero)
        {
            _animator.Play(IdleAnimation);
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                _animator.Play(MovingHorisontalAnimation);
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180));
                _animator.Play(MovingHorisontalAnimation);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                _animator.Play(MovingUpAnimation);
            }
            else
            {
                _animator.Play(MovingDownAnimation);
            }
        }
    }
}
