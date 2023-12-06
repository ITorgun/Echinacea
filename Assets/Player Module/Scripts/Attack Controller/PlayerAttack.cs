using UnityEngine;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public PlayerShootPosition ShotPosition { get; set; }
    public IRangeAttackDealer RangeAttackDealer { get; set; }

    [Inject]
    public void Construct(PlayerShootPosition shotPosition, IRangeAttackDealer rangeAttackDealer)
    {
        ShotPosition = shotPosition;
        RangeAttackDealer = rangeAttackDealer;
    }

}
