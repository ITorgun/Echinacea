using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string IdleAnimation = "Idle";
    private readonly string MovingDownAnimation = "MovingDown";
    private readonly string MovingUpAnimation = "MovingUp";
    private readonly string MovingHorisontalAnimation = "MovingHorisontal";

    private readonly string ShootingHorisontalAnimation = "ShootHorisontal";
    private readonly string ShootingDownAnimation = "ShootDown";
    private readonly string ShootingUpAnimation = "ShootUp";

    public void PlayMovementAnimation(Vector2 direction)
    {
        PlayAnimation(direction, MovingHorisontalAnimation, MovingUpAnimation, MovingDownAnimation);
    }

    public void PlayShootAnimation(Vector2 direction)
    {
        PlayAnimation(direction, ShootingHorisontalAnimation, ShootingUpAnimation, ShootingDownAnimation);
    }

    private void PlayAnimation(Vector2 direction, string horisontalClip, string upClip, string downClip)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0));

        if (direction == Vector2.zero)
        {
            _animator.Play(IdleAnimation);
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180));
            }

            _animator.Play(horisontalClip);
        }
        else
        {
            if (direction.y > 0)
            {
                _animator.Play(upClip);
            }
            else
            {
                _animator.Play(downClip);
            }
        }
    }
}
